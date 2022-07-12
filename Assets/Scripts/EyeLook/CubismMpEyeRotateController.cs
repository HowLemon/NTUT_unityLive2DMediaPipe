using Live2D.Cubism.Core;
using UnityEngine;

using Object = UnityEngine.Object;


namespace Live2D.Cubism.Framework.MediaPipeControll.EyeRotate
{
    public sealed class CubismMpEyeRotateController : MonoBehaviour, ICubismUpdatable
    {
        [SerializeField]
        public CubismParameterBlendMode BlendMode = CubismParameterBlendMode.Additive;


        [SerializeField, HideInInspector] private Object _target;

        public Object Target
        {
            get { return _target; }
            set { _target = value.ToNullUnlessImplementsInterface<ICubismMpEyeRotateTarget>(); }
        }


        private ICubismMpEyeRotateTarget _targetInterface;

        private ICubismMpEyeRotateTarget TargetInterface
        {
            get
            {
                if (_targetInterface == null)
                {
                    _targetInterface = Target.GetInterface<ICubismMpEyeRotateTarget>();
                }


                return _targetInterface;
            }
        }

        public Transform Center;

        public float Damping = 0.15f;

        private CubismMpEyeRotateParameter[] Sources { get; set; }

        private CubismParameter[] Destinations { get; set; }

        private Vector3 LastPosition { get; set; }

        private Vector3 GoalPosition { get; set; }

        private Vector3 VelocityBuffer;

        [HideInInspector]
        public bool HasUpdateController { get; set; }

        public void Refresh()
        {
            var model = this.FindCubismModel();


            // Catch sources and destinations.
            Sources = model
                .Parameters
                .GetComponentsMany<CubismMpEyeRotateParameter>();
            Destinations = new CubismParameter[Sources.Length];


            for (var i = 0; i < Sources.Length; ++i)
            {
                Destinations[i] = Sources[i].GetComponent<CubismParameter>();
            }

            // Get cubism update controller.
            HasUpdateController = (GetComponent<CubismUpdateController>() != null);
        }

        public int ExecutionOrder
        {
            get { return CubismUpdateExecutionOrder.CubismMpEyeRotateController; }
        }

        public bool NeedsUpdateOnEditing
        {
            get { return false; }
        }

        public void OnLateUpdate()
        {
            // Return if it is not valid or there's nothing to update.
            if (!enabled || Destinations == null)
            {
                return;
            }


            // Return early if no target is available or if target is inactive.
            var target = TargetInterface;


            if (target == null || !target.IsActive())
            {
                return;
            }


            // Update position.
            var position = LastPosition;
            GoalPosition = transform.InverseTransformPoint(target.GetPosition()) - Center.localPosition;


            if (position != GoalPosition)
            {
                position = Vector3.SmoothDamp(
                    position,
                    GoalPosition,
                    ref VelocityBuffer,
                    Damping);
            }


            // Update sources and destinations.
            for (var i = 0; i < Destinations.Length; ++i)
            {
                Destinations[i].BlendToValue(BlendMode, Sources[i].TickAndEvaluate(position));
            }


            // Store position.
            LastPosition = position;
        }

        #region Unity Events Handling

        private void Start()
        {
            // Default center if necessary.
            if (Center == null)
            {
                Center = transform;
            }


            // Initialize cache.
            Refresh();
        }

        private void LateUpdate()
        {
            if (!HasUpdateController)
            {
                OnLateUpdate();
            }
        }

        #endregion
    }
}

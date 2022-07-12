using System.Collections.Generic;
using Live2D.Cubism.Core;
using UnityEngine;
using Mediapipe;

namespace Live2D.Cubism.Framework.MediaPipeControll.RightEyeBlink
{
    public class CubismMpRightEyeBlinkController : MonoBehaviour, ICubismUpdatable
    {
        [SerializeField]
        public CubismParameterBlendMode BlendMode = CubismParameterBlendMode.Multiply;


        private GameObject faceLandmarkListAnnotation;
        private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
        private List<GameObject> faceNodes;

        private float LastValue { get; set; }

        private float VelocityBuffer;

        public float Damping = 0.15f;

        [SerializeField, Range(0f, 1f)]
        public float EyeOpening = 1f;

        private CubismParameter[] Destinations { get; set; }

        [HideInInspector]
        public bool HasUpdateController { get; set; }

        public void Refresh()
        {
            var model = this.FindCubismModel();


            // Fail silently...
            if (model == null)
            {
                return;
            }


            // Cache destinations.
            var tags = model
                .Parameters
                .GetComponentsMany<CubismMpRightEyeBlinkParameter>();


            Destinations = new CubismParameter[tags.Length];


            for (var i = 0; i < tags.Length; ++i)
            {
                Destinations[i] = tags[i].GetComponent<CubismParameter>();
            }

            // Get cubism update controller.
            HasUpdateController = (GetComponent<CubismUpdateController>() != null);
        }

        public int ExecutionOrder
        {
            get { return CubismUpdateExecutionOrder.CubismMpRightEyeBlinkController; }
        }

        /// <summary>
        /// Called by cubism update controller. Needs to invoke OnLateUpdate on Editing.
        /// </summary>
        public bool NeedsUpdateOnEditing
        {
            get { return false; }
        }

        /// <summary>
        /// Called by cubism update controller. Updates controller.
        /// </summary>
        public void OnLateUpdate()
        {
            // Fail silently.
            if (!enabled || Destinations == null)
            {
                return;
            }

            var position = LastValue;

            if (position != EyeOpening)
            {
                position = Mathf.SmoothDamp(
                    position,
                    EyeOpening,
                    ref VelocityBuffer,
                    Damping);
            }

            // Apply value.
            Destinations.BlendToValue(BlendMode, EyeOpening);
            LastValue = EyeOpening;
        }

        #region Unity Event Handling


        /// <summary>
        /// Called by Unity. Makes sure cache is initialized.
        /// </summary>
        private void Start()
        {
            // Initialize cache.
            Refresh();
        }


        private void Update()
        {
            if (faceLandmarkListAnnotation == null && GameObject.Find("FaceLandmarkListAnnotation(Clone)") == true)
            {
                faceLandmarkListAnnotation = GameObject.Find("FaceLandmarkListAnnotation(Clone)");
                faceLandmarkListAnnotationController = faceLandmarkListAnnotation.GetComponent<FaceLandmarkListAnnotationController>();
                faceNodes = faceLandmarkListAnnotationController.getNodes;
            }
            if (faceNodes != null)
            {
                EyeOpening = Vector3.Distance(faceNodes[159].transform.position, faceNodes[145].transform.position) / Vector3.Distance(faceNodes[4].transform.position, faceNodes[5].transform.position);
            }
        }
        /// <summary>
        /// Called by Unity.
        /// </summary>
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


using System.Collections.Generic;
using Live2D.Cubism.Core;
using UnityEngine;
using Mediapipe;

namespace Live2D.Cubism.Framework.MediaPipeControll.MouthOpen
{
    public class CubismMpMouthOpenController : MonoBehaviour, ICubismUpdatable
    {
        [SerializeField]
        public CubismParameterBlendMode BlendMode = CubismParameterBlendMode.Multiply;


        private GameObject faceLandmarkListAnnotation;
        private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
        private List<GameObject> faceNodes;

        [SerializeField, Range(0f, 1f)]
        public float MouthOpening = 1f;

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
                .GetComponentsMany<CubismMpMouthOpenParameter>();


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
            get { return CubismUpdateExecutionOrder.CubismMpMouthOpenController; }
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


            // Apply value.
            Destinations.BlendToValue(BlendMode, MouthOpening);
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
                MouthOpening = Vector3.Distance(faceNodes[13].transform.position, faceNodes[14].transform.position) / Vector3.Distance(faceNodes[4].transform.position, faceNodes[5].transform.position);
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


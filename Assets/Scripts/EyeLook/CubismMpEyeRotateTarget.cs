using Live2D.Cubism.Core;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe;

namespace Live2D.Cubism.Framework.MediaPipeControll.EyeRotate
{

    public class CubismMpEyeRotateTarget : MonoBehaviour, ICubismMpEyeRotateTarget
    {
        private GameObject leftIrisLandmarksAnnotation;
        private IrisAnnotationController leftIrisLandmarksAnnotationController;
        private List<GameObject> nodes;

        private GameObject faceLandmarkListAnnotation;
        private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
        private List<GameObject> faceNodes;

        private float targetX = 0.0f;
        private float targetY = 0.0f;

        public int coefX = 90;
        public int coefY = 50;


        public Vector3 GetPosition()
        {
            var targetPosition = new Vector3(targetX, targetY, 0.0f);
            //Debug.Log(targetPosition);
            return targetPosition;
        }

        public bool IsActive()
        {
            return true;
        }

        void Update() 
        {
            if (faceLandmarkListAnnotation == null && GameObject.Find("FaceLandmarkListAnnotation(Clone)") == true)
            {
                faceLandmarkListAnnotation = GameObject.Find("FaceLandmarkListAnnotation(Clone)");
                faceLandmarkListAnnotationController = faceLandmarkListAnnotation.GetComponent<FaceLandmarkListAnnotationController>();
                faceNodes = faceLandmarkListAnnotationController.getNodes;
            }
            if (leftIrisLandmarksAnnotation == null && GameObject.Find("leftIrisLandmarksAnnotation") == true)
            {
                leftIrisLandmarksAnnotation = GameObject.Find("leftIrisLandmarksAnnotation");
                leftIrisLandmarksAnnotationController = leftIrisLandmarksAnnotation.GetComponent<IrisAnnotationController>();
                nodes = leftIrisLandmarksAnnotationController.getNodes;
            }
            if (faceNodes != null && nodes != null)
            {
                targetX = (nodes[0].transform.position.x - ((faceNodes[159].transform.position.x + faceNodes[145].transform.position.x) / 2)) * coefX;
            }
            if (faceNodes != null && nodes != null)
            {
                targetY = (nodes[0].transform.position.y - ((faceNodes[133].transform.position.y + faceNodes[33].transform.position.y) / 2)) * coefY;
            }
        }
    }
}
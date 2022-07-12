using Live2D.Cubism.Core;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe;

namespace Live2D.Cubism.Framework.MediaPipeControll.FaceRotate
{

    public class CubismMpFaceRotateTarget : MonoBehaviour, ICubismMpFaceRotateTarget
    {
        private GameObject faceLandmarkListAnnotation;
        private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
        private List<GameObject> faceNodes;

        private float targetX = 0.0f;
        private float targetY = 0.0f;
        private float targetZ = 0.0f;

        public int coefX = 30;
        public int coefY = 30;
        public int coefZ = 1;
        

        public Vector3 GetPosition()
        {
            var targetPosition = new Vector3(targetX, targetY, targetZ);
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
            if (faceNodes != null)
            {
                targetX = (faceNodes[133].transform.position.x + faceNodes[362].transform.position.x - faceNodes[1].transform.position.x * 2)* coefX;
                targetY = (faceNodes[1].transform.position.y * 2 - ((faceNodes[133].transform.position.y + faceNodes[362].transform.position.y) / 2 + faceNodes[14].transform.position.y))* coefY;
                targetZ = (faceNodes[0].transform.position.x - faceNodes[1].transform.position.x)* coefZ;
            }
        }
    }
}
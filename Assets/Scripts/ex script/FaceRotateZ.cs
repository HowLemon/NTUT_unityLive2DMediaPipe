using Live2D.Cubism.Core;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe;

public class FaceRotateZ : MonoBehaviour
{
    private GameObject detectionAnnotation;
    private DetectionAnnotationController detectionAnnotationController;
    private List<GameObject> Keypoints;

    private float z = 0.0f;

    private CubismParameter cubismParameter;

    void Start()
    {
        cubismParameter = GetComponent<CubismParameter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (detectionAnnotation == null)
        {
            detectionAnnotation = GameObject.Find("DetectionAnnotation(Clone)");
            detectionAnnotationController = detectionAnnotation.GetComponent<DetectionAnnotationController>();
            Keypoints = detectionAnnotationController.getKeyPoints;
        }


        if (Keypoints != null)
        {
            z = (Keypoints[0].transform.position.y - Keypoints[1].transform.position.y);
        }
    }
    private void LateUpdate()
    {
        float newZ = (float)(Mathf.Round(z * 15 * 10)) / 10;
        cubismParameter.Value = newZ;
    }
}

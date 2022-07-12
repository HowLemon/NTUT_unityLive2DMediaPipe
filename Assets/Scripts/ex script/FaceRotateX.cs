using Live2D.Cubism.Core;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe;

public class FaceRotateX : MonoBehaviour
{
    private GameObject detectionAnnotation;
    private DetectionAnnotationController detectionAnnotationController;
    private List<GameObject> Keypoints;

    private float x = 0.0f;

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
            x = (Keypoints[0].transform.position.x + Keypoints[1].transform.position.x - Keypoints[2].transform.position.x * 2);
        }
    }
    private void LateUpdate()
    {
        float newX = (float)(Mathf.Round(x * 30 * 10)) / 10;
        cubismParameter.Value = newX;
    }
}

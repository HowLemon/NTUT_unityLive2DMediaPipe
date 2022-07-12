using Live2D.Cubism.Core;
using System.Collections.Generic;
using UnityEngine;
using Mediapipe;

public class FaceRotateY : MonoBehaviour
{
    private GameObject detectionAnnotation;
    private DetectionAnnotationController detectionAnnotationController;
    private List<GameObject> Keypoints;

    private int y = 0;

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
            y = ((int)(Keypoints[2].transform.position.y * 2 - ((Keypoints[0].transform.position.y + Keypoints[1].transform.position.y) / 2 + Keypoints[3].transform.position.y)));
        }
    }
    private void LateUpdate()
    {
        float newY = (float)(Mathf.Round(y * 10 * 10)) / 10;
        cubismParameter.Value = newY;
    }
}

using System.Collections.Generic;
using Live2D.Cubism.Core;
using Mediapipe;
using UnityEngine;

public class IrisEye_Y : MonoBehaviour
{
    private GameObject leftIrisLandmarksAnnotation;
    private IrisAnnotationController leftIrisLandmarksAnnotationController;
    private List<GameObject> nodes;

    private GameObject faceLandmarkListAnnotation;
    private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
    private List<GameObject> faceNodes;

    private float eyeY = 0.0f;

    private CubismParameter cubismParameter;
    // Start is called before the first frame update
    void Start()
    {
        cubismParameter = GetComponent<CubismParameter>();
    }

    // Update is called once per frame
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
            eyeY = nodes[0].transform.position.y - ((faceNodes[133].transform.position.y + faceNodes[33].transform.position.y) / 2);
        }
    }
    private void LateUpdate()
    {
        float newY = eyeY * 10;
        cubismParameter.Value = newY;
    }
}

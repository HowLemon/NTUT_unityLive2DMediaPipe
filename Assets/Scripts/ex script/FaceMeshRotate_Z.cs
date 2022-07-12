using System.Collections.Generic;
using Live2D.Cubism.Core;
using Mediapipe;
using UnityEngine;

public class FaceMeshRotate_Z : MonoBehaviour
{
    private GameObject faceLandmarkListAnnotation;
    private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
    private List<GameObject> faceNodes;

    private float z = 0.0f;

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
        if (faceNodes != null)
        {
            z = (faceNodes[0].transform.position.x - faceNodes[1].transform.position.x);
        }
    }
    private void LateUpdate()
    {
        float newZ = -(float)(Mathf.Round(z * 15 * 10)) / 10;
        cubismParameter.Value = newZ;
    }
}

using System.Collections.Generic;
using Live2D.Cubism.Core;
using Mediapipe;
using UnityEngine;

public class FaceMeshRotate_Y : MonoBehaviour
{
    private GameObject faceLandmarkListAnnotation;
    private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
    private List<GameObject> faceNodes;

    private float y = 0.0f;

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
            y = (faceNodes[1].transform.position.y * 2 - ((faceNodes[133].transform.position.y + faceNodes[362].transform.position.y) / 2 + faceNodes[14].transform.position.y));
        }
    }
    private void LateUpdate()
    {
        float newY = (float)(Mathf.Round(y * 10 * 10)) / 10;
        cubismParameter.Value = newY;
    }
}

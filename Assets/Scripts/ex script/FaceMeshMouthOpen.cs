using System.Collections.Generic;
using Live2D.Cubism.Core;
using Mediapipe;
using UnityEngine;

public class FaceMeshMouthOpen : MonoBehaviour
{
    private GameObject faceLandmarkListAnnotation;
    private FaceLandmarkListAnnotationController faceLandmarkListAnnotationController;
    private List<GameObject> faceNodes;

    private float mouthCloseDistance = 0.0f;

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
            mouthCloseDistance = Vector3.Distance(faceNodes[13].transform.position, faceNodes[14].transform.position) / Vector3.Distance(faceNodes[4].transform.position, faceNodes[5].transform.position);
        }
    }
    private void LateUpdate()
    {
        float newDistance = (float)(Mathf.Round(mouthCloseDistance * 10)) / 10;
        cubismParameter.Value = newDistance;
    }
}

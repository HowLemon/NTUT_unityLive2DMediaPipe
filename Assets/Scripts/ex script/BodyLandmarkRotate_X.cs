using System.Collections.Generic;
using Live2D.Cubism.Core;
using Mediapipe;
using UnityEngine;

public class BodyLandmarkRotate_X : MonoBehaviour
{
    private GameObject fullBodyPoseLandmarkListAnnotation;
    private FullBodyPoseLandmarkListAnnotationController fullBodyPoseLandmarkListAnnotationController;
    private List<GameObject> bodyNodes;

    private float bodyAngle = 0.0f;

    private CubismParameter cubismParameter;
    // Start is called before the first frame update
    void Start()
    {
        cubismParameter = GetComponent<CubismParameter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fullBodyPoseLandmarkListAnnotation == null && GameObject.Find("FullBodyPoseLandmarkListAnnotation(Clone)") == true)
        {
            fullBodyPoseLandmarkListAnnotation = GameObject.Find("FullBodyPoseLandmarkListAnnotation(Clone)");
            fullBodyPoseLandmarkListAnnotationController = fullBodyPoseLandmarkListAnnotation.GetComponent<FullBodyPoseLandmarkListAnnotationController>();
            bodyNodes = fullBodyPoseLandmarkListAnnotationController.getNodes;
        }
        if (bodyNodes != null)
        {
            var angle1 = Vector2.Angle(bodyNodes[12].transform.position - bodyNodes[11].transform.position, bodyNodes[24].transform.position - bodyNodes[12].transform.position);
            var angle2 = Vector2.Angle(bodyNodes[11].transform.position - bodyNodes[12].transform.position, bodyNodes[23].transform.position - bodyNodes[11].transform.position);
            bodyAngle = angle1 - angle2;
        }
    }
    private void LateUpdate()
    {
        float newAngle = (float)(Mathf.Round(bodyAngle * 10)) / 10;
        cubismParameter.Value = newAngle;
    }
}

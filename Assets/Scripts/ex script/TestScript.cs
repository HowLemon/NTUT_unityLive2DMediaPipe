using UnityEngine;
using System.Collections.Generic;
using Mediapipe;

public class TestScript : MonoBehaviour
{
    private GameObject leftHandLandmarksAnnotation;
    private HandLandmarkListAnnotationController leftHandLandmarkListAnnotationController;
    private List<GameObject> leftNodes;

    private GameObject rightHandLandmarksAnnotation;
    private HandLandmarkListAnnotationController rightHandLandmarkListAnnotationController;
    private List<GameObject> rightNodes;

    float leftFinger1Angle = 180.0f;
    float leftFinger2Angle = 180.0f;
    float leftFinger3Angle = 180.0f;
    float leftFinger4Angle = 180.0f;
    float leftFinger5Angle = 180.0f;

    bool leftFinger1State = true;
    bool leftFinger2State = true;
    bool leftFinger3State = true;
    bool leftFinger4State = true;
    bool leftFinger5State = true;

    int leftHandNumber = 0;

    float rightFinger1Angle = 180.0f;
    float rightFinger2Angle = 180.0f;
    float rightFinger3Angle = 180.0f;
    float rightFinger4Angle = 180.0f;
    float rightFinger5Angle = 180.0f;

    bool rightFinger1State = true;
    bool rightFinger2State = true;
    bool rightFinger3State = true;
    bool rightFinger4State = true;
    bool rightFinger5State = true;

    int rightHandNumber = 0;

    int totalNumber = 0;

    public GameObject model;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (leftHandLandmarksAnnotation == null && GameObject.Find("leftHandLandmarksAnnotation") == true)
        {
            leftHandLandmarksAnnotation = GameObject.Find("leftHandLandmarksAnnotation");
            leftHandLandmarkListAnnotationController = leftHandLandmarksAnnotation.GetComponent<HandLandmarkListAnnotationController>();
            leftNodes = leftHandLandmarkListAnnotationController.getNodes;
        }

        if (leftNodes != null)
        {
            leftFinger1Angle = Vector2.Angle(leftNodes[3].transform.position - leftNodes[2].transform.position, leftNodes[1].transform.position - leftNodes[2].transform.position);
            leftFinger2Angle = Vector2.Angle(leftNodes[7].transform.position - leftNodes[6].transform.position, leftNodes[5].transform.position - leftNodes[6].transform.position);
            leftFinger3Angle = Vector2.Angle(leftNodes[11].transform.position - leftNodes[10].transform.position, leftNodes[9].transform.position - leftNodes[10].transform.position);
            leftFinger4Angle = Vector2.Angle(leftNodes[15].transform.position - leftNodes[14].transform.position, leftNodes[13].transform.position - leftNodes[14].transform.position);
            leftFinger5Angle = Vector2.Angle(leftNodes[19].transform.position - leftNodes[18].transform.position, leftNodes[17].transform.position - leftNodes[18].transform.position);
            leftFingerState();
        }

        if (rightHandLandmarksAnnotation == null && GameObject.Find("rightHandLandmarksAnnotation") == true)
        {
            rightHandLandmarksAnnotation = GameObject.Find("rightHandLandmarksAnnotation");
            rightHandLandmarkListAnnotationController = rightHandLandmarksAnnotation.GetComponent<HandLandmarkListAnnotationController>();
            rightNodes = rightHandLandmarkListAnnotationController.getNodes;
        }

        if (rightNodes != null)
        {
            rightFinger1Angle = Vector2.Angle(rightNodes[3].transform.position - rightNodes[2].transform.position, rightNodes[1].transform.position - rightNodes[2].transform.position);
            rightFinger2Angle = Vector2.Angle(rightNodes[7].transform.position - rightNodes[6].transform.position, rightNodes[5].transform.position - rightNodes[6].transform.position);
            rightFinger3Angle = Vector2.Angle(rightNodes[11].transform.position - rightNodes[10].transform.position, rightNodes[9].transform.position - rightNodes[10].transform.position);
            rightFinger4Angle = Vector2.Angle(rightNodes[15].transform.position - rightNodes[14].transform.position, rightNodes[13].transform.position - rightNodes[14].transform.position);
            rightFinger5Angle = Vector2.Angle(rightNodes[19].transform.position - rightNodes[18].transform.position, rightNodes[17].transform.position - rightNodes[18].transform.position);
            rightFingerState();
        }

        if (totalNumber != (leftHandNumber + rightHandNumber))
        {
            animator.SetTrigger((leftHandNumber + rightHandNumber).ToString());
            totalNumber = leftHandNumber + rightHandNumber;
        }

    }
    private void leftFingerState() 
    {
        if (leftFinger1Angle <= 140)
        {
            leftFinger1State = false;
        }
        else 
        {
            leftFinger1State = true;
        }
        if (leftFinger2Angle <= 140)
        {
            leftFinger2State = false;
        }
        else
        {
            leftFinger2State = true;
        }
        if (leftFinger3Angle <= 140)
        {
            leftFinger3State = false;
        }
        else
        {
            leftFinger3State = true;
        }
        if (leftFinger4Angle <= 140)
        {
            leftFinger4State = false;
        }
        else
        {
            leftFinger4State = true;
        }
        if (leftFinger5Angle <= 140)
        {
            leftFinger5State = false;
        }
        else
        {
            leftFinger5State = true;
        }

        if (leftFinger2State == false && leftFinger3State == false && leftFinger4State == false && leftFinger5State == false)
        {
            leftHandNumber = 0;
        }
        else if (leftFinger2State == true && leftFinger3State == false && leftFinger4State == false && leftFinger5State == false)
        {
            leftHandNumber = 1;
        }
        else if (leftFinger2State == true && leftFinger3State == true && leftFinger4State == false && leftFinger5State == false)
        {
            leftHandNumber = 2;
        }
        else if (leftFinger2State == true && leftFinger3State == true && leftFinger4State == true && leftFinger5State == false)
        {
            leftHandNumber = 3;
        }
        else if (leftFinger2State == true && leftFinger3State == true && leftFinger4State == true && leftFinger5State == true)
        {
            leftHandNumber = 4;
        }
    }
    private void rightFingerState()
    {
        if (rightFinger1Angle <= 140)
        {
            rightFinger1State = false;
        }
        else
        {
            rightFinger1State = true;
        }
        if (rightFinger2Angle <= 140)
        {
            rightFinger2State = false;
        }
        else
        {
            rightFinger2State = true;
        }
        if (rightFinger3Angle <= 140)
        {
            rightFinger3State = false;
        }
        else
        {
            rightFinger3State = true;
        }
        if (rightFinger4Angle <= 140)
        {
            rightFinger4State = false;
        }
        else
        {
            rightFinger4State = true;
        }
        if (rightFinger5Angle <= 140)
        {
            rightFinger5State = false;
        }
        else
        {
            rightFinger5State = true;
        }

        if (rightFinger2State == false && rightFinger3State == false && rightFinger4State == false && rightFinger5State == false)
        {
            rightHandNumber = 0;
        }
        else if (rightFinger2State == true && rightFinger3State == false && rightFinger4State == false && rightFinger5State == false)
        {
            rightHandNumber = 1;
        }
        else if (rightFinger2State == true && rightFinger3State == true && rightFinger4State == false && rightFinger5State == false)
        {
            rightHandNumber = 2;
        }
        else if (rightFinger2State == true && rightFinger3State == true && rightFinger4State == true && rightFinger5State == false)
        {
            rightHandNumber = 3;
        }
        else if (rightFinger2State == true && rightFinger3State == true && rightFinger4State == true && rightFinger5State == true)
        {
            rightHandNumber = 4;
        }
    }
}

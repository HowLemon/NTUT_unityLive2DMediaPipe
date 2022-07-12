using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 mouseDownPoint;
    private Vector2 mouseMovingPoint;
    private Vector2 mouseMoveDistance;

    private void OnMouseDown()
    {
        mouseDownPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseMovingPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }

    private void OnMouseDrag()
    {
        mouseMovingPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mouseMoveDistance = mouseMovingPoint - mouseDownPoint;
        transform.parent.Translate(mouseMoveDistance);
    }
}

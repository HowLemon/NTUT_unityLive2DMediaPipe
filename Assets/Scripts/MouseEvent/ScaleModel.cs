using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModel : MonoBehaviour
{

    private float scaleValue;
    private float lastScaleValue;

    private Vector3 scaleChange;

    public GameObject refGameObject;

    private void OnMouseOver()
    {
        scaleValue += Input.mouseScrollDelta.y * 0.1f;

        if (scaleValue != lastScaleValue)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(mousePos);
            var tempGameObject = Instantiate(refGameObject, mousePos, Quaternion.identity);
            gameObject.transform.parent.parent = tempGameObject.transform;

            //scaleChange = new Vector3(transform.parent.localScale.x + (scaleValue-lastScaleValue), transform.parent.localScale.y + (scaleValue - lastScaleValue), 1.0f);
            //transform.parent.localScale = scaleChange;
            scaleChange = new Vector3(transform.parent.parent.localScale.x + (scaleValue - lastScaleValue), transform.parent.parent.localScale.y + (scaleValue - lastScaleValue), 1.0f);
            transform.parent.parent.localScale = scaleChange;
            transform.parent.parent = null;
            Destroy(tempGameObject);
            lastScaleValue = scaleValue;
        }
    }

    private void start()
    {
        refGameObject = new GameObject("refGameObject");

        scaleValue = 0.0f;
        lastScaleValue = 0.0f;
    }
}

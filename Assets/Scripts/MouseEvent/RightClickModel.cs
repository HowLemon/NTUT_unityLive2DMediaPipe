using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClickModel : MonoBehaviour
{
    public GameObject UI;

    public GameObject webCamScreen;

    private void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (UI.activeSelf == false)
            {
                UI.SetActive(true);
                webCamScreen.transform.position = new Vector3(0, 0, 20.0f); 
            }
            else 
            {
                UI.SetActive(false);
                webCamScreen.transform.position = new Vector3(0, 0, -20.0f);
            }
        }

    }
}

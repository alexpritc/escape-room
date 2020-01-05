using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControls : MonoBehaviour
{
    public GameObject controls;
    public static bool isShowing = false;

    void Start()
    {
        if (this.gameObject.name == "Controls Button") {
            isShowing = false;
            controls.SetActive(false);
        }
    }

    public void ButtonClicked()
    {
        if (isShowing)
        {
            controls.SetActive(false);
            isShowing = false;
        }
        else {
            controls.SetActive(true);
            isShowing = true;
        }
    }

}

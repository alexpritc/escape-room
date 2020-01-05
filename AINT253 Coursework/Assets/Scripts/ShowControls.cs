using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControls : MonoBehaviour
{
    public GameObject controls;
    public bool isShowing = false;

    void Update()
    {
        if (controls.activeInHierarchy)
        {
            isShowing = true;
        }
        else {
            isShowing = false;
        }
    }

    public void ButtonClicked()
    {
        if (isShowing)
        {
            controls.SetActive(false);
        }
        else {
            controls.SetActive(true);
        }
    }

}

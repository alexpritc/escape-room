using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCursor : MonoBehaviour
{
    public bool hideCursor = false;

    // Start is called before the first frame update
    void Start()
    {
        if (hideCursor == true)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }

    }
}

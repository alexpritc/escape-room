using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLights : MonoBehaviour
{
    private Animator keypadAnim;

    // Start is called before the first frame update
    void Start()
    {
        keypadAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keypadAnim.GetBool("isWrong"))
        {
            Invoke("ResetBool", 0.5f);
        }
    }

    void ResetBool()
    {
        keypadAnim.SetBool("isWrong", false);
    }
}

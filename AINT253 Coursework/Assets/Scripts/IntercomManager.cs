using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercomManager : MonoBehaviour
{

    public GameObject animation;
    public GameObject light;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = animation.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isOn"))
        {
            light.SetActive(true);
        }
        else {

            light.SetActive(false);
        }
    }
}

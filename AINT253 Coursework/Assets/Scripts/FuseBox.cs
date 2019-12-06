using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public static bool switch1 = false;
    public static bool switch2 = false;
    public static bool switch3 = false;
    public static bool switch4 = false;

    public static bool fuseboxPuzzleComplete = false;

    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switch1 && !switch2 && !switch3 && switch4)
        {
            particles.SetActive(false);
            fuseboxPuzzleComplete = true;
        }
    }
}

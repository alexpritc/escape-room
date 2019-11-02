using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRayCast : MonoBehaviour
{
    public static bool didHitButton = false;
    public static RaycastHit hitDuplicate;

    // Update is called once per frame
    void FixedUpdate()
    {
        // Bit shift the index of the layer (9) to get a bit mask
        int layerMask = 1 << 9;

        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Debug.DrawRay(transform.position, fwd, Color.red);

        if (Physics.Raycast(transform.position, fwd, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, fwd * hit.distance, Color.yellow);

            didHitButton = true;
            hitDuplicate = hit;
        }
        else
        {
            didHitButton = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform destination;

    // Update is called once per frame
    void Update()
    {
        if (PlayerRayCast.didHitObject && PlayerRayCast.hitDuplicate.collider.gameObject == this.gameObject && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = destination.position;
            this.transform.parent = destination;
        }
        else
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}

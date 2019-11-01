using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Walls")
        {
            PlayerMovement.speed = 1f;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Walls")
        {
            PlayerMovement.speed = 15f;
        }
    }
}

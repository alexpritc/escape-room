using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public GameObject handle;
    public GameObject door;

    private Animator handleAnim;
    private Animator doorAnim;

    private Rigidbody rb;

    void Start()
    {
        handleAnim = handle.GetComponent<Animator>();
        doorAnim = door.GetComponent<Animator>();

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

    void OnTriggerStay(Collider other)
    {
        if (other.name == "Door Handle Rot")
        {
            Debug.Log("Press E.");

            if (Input.GetKeyDown(KeyCode.E))
            {
                handleAnim.SetBool("isUsed", true);
                Invoke("Buffer", 0.1f);

                Invoke("OpenDoor", 0.1f);
            }
        }
    }

    void Buffer()
    {
        handleAnim.SetBool("isUsed", false);
    }

    void OpenDoor()
    {
        doorAnim.SetBool("IsOpened", true);
    }
}

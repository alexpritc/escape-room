using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public static bool allPuzzlesComplete = true;
    public static bool wirePuzzleComplete = true;

    public GameObject handle;
    public GameObject door;
    public GameObject computerScreen;

    public Material darkGrey;
    public Material spaceInvaders;
    public Material cctv;

    private Animator handleAnim;
    private Animator doorAnim;

    private Rigidbody rb;

    private MeshRenderer pcMeshR;

    private bool isComputerOn = false;

    void Start()
    {
        handleAnim = handle.GetComponent<Animator>();
        doorAnim = door.GetComponent<Animator>();

        rb = gameObject.GetComponent<Rigidbody>();

        pcMeshR = computerScreen.GetComponent<MeshRenderer>();
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

            // Play door handle sound here.

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (allPuzzlesComplete)
                {
                    Invoke("OpenDoor", 0.2f);
                }
                else
                {
                    // Play door locked sound here.
                }

                handleAnim.SetBool("isUsed", true);
                Invoke("Buffer", 0.1f);

            }
        }

        if (other.tag == "Computer")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isComputerOn == true)
                {
                    // Play switch on/off sound.
                    pcMeshR.material = darkGrey;

                    isComputerOn = false;
                    Debug.Log("Switching off..");
                }
                else if (isComputerOn == false && wirePuzzleComplete == true)
                {
                    // Play switch on/off sound.
                    pcMeshR.material = cctv;

                    isComputerOn = true;
                    Debug.Log("Switching on..");
                }
                else
                {
                    // Play switch on/off sound.
                    pcMeshR.material = spaceInvaders;

                    isComputerOn = true;
                    Debug.Log("Switching on..");
                }
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

        // Play door opening sound here.
    }
}

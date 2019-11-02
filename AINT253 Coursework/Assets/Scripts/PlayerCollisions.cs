using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public static bool allPuzzlesComplete = false;
    public static bool wirePuzzleComplete = true;

    public GameObject handle;
    public GameObject door;
    public GameObject computerScreen;
    public Light computerlight;

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

        computerlight.enabled = false;
    }

    void Update()
    {
        // Check all the puzzles have been completed.

        if (KeypadManager.isKeypadPuzzleComplete == true)
        {
            allPuzzlesComplete = true;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Walls")
        {
            PlayerMovement.speed = 2.5f;
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

        // Attempts to use the door handle.
        if (other.name == "Door Handle Rot")
        {
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

        // Turning the computer on and off.
        if (other.tag == "Computer")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isComputerOn == true)
                {
                    // Play switch off sound.
                    pcMeshR.material = darkGrey;

                    computerlight.enabled = false;

                    isComputerOn = false;
                }
                else if (isComputerOn == false && wirePuzzleComplete == true)
                {
                    // Play switch on sound.
                    pcMeshR.material = cctv;

                    computerlight.enabled = true;

                    isComputerOn = true;
                }
                else
                {
                    // Play switch on sound.
                    pcMeshR.material = spaceInvaders;

                    computerlight.enabled = true;

                    isComputerOn = true;
                }
            }
        }

        // Pressing buttons on the keypad.
        if (other.tag == "Button" && PlayerRayCast.didHitButton == true && KeypadManager.isKeypadPuzzleComplete == false)
        {
            if (Input.GetKeyDown(KeyCode.E) && KeypadManager.playerInput.Length < 4)
            {
                // Play button sound here.

                // Visual feedback.

                // Send the button pressed to the keypad to add it to the current input.
                KeypadManager.AddToCode(PlayerRayCast.hitDuplicate.collider.name);
                Debug.Log("Sending " + PlayerRayCast.hitDuplicate.collider.name);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public static bool allPuzzlesComplete = false;

    public GameObject handle;
    public GameObject door;

    public GameObject computerScreen;
    public GameObject code;
    public Light computerlight;

    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;

    public Material darkGrey;
    public Material cctv;

    public Text pressE;

    private Animator handleAnim;
    private Animator doorAnim;

    private Animator switch1Anim;
    private Animator switch2Anim;
    private Animator switch3Anim;
    private Animator switch4Anim;

    private Rigidbody rb;

    private MeshRenderer pcMeshR;

    private bool isComputerOn = false;

    private bool hasComputerBeenTurnedOn = false;

    void Start()
    {
        handleAnim = handle.GetComponent<Animator>();
        doorAnim = door.GetComponent<Animator>();

        switch1Anim = switch1.GetComponent<Animator>();
        switch2Anim = switch2.GetComponent<Animator>();
        switch3Anim = switch3.GetComponent<Animator>();
        switch4Anim = switch4.GetComponent<Animator>();

        rb = gameObject.GetComponent<Rigidbody>();

        pcMeshR = computerScreen.GetComponent<MeshRenderer>();

        computerlight.enabled = false;
        code.SetActive(false);

        pressE.enabled = false;
    }

    void Update()
    {
        if (FuseBox.fuseboxPuzzleComplete && !hasComputerBeenTurnedOn)
        {
            hasComputerBeenTurnedOn = true;
            // Play switch on sound.
            pcMeshR.material = cctv;

            computerlight.color = Color.red;
            computerlight.enabled = true;
            code.SetActive(true);

            isComputerOn = true;
        }

        // Check all the puzzles have been completed.
        if (KeypadManager.isKeypadPuzzleComplete)
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
        if (other.tag == "Door Handle" && PlayerRayCast.didHitHandle)
        {
            pressE.enabled = true;

            // Play door handle sound here.

            if (Input.GetKeyDown(KeyCode.E))
            { 
                if (!doorAnim.GetBool("isOpened"))
                {
                    if (allPuzzlesComplete)
                    {
                        Invoke("OpenDoor", 0.2f);
                        
                    }
                    else
                    {
                        // Play door locked sound here.
                    }
                }
                else
                {
                    // Remove interactions from the door handle.
                }

                handleAnim.SetBool("isUsed", true);
                Invoke("Buffer", 0.1f);
            }
        }
        // Turning the computer on and off.
        else if (other.tag == "Computer" && PlayerRayCast.didHitComputer)
        {
            pressE.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (isComputerOn)
                {
                    // Play switch off sound.
                    pcMeshR.material = darkGrey;

                    computerlight.enabled = false;
                    code.SetActive(false);

                    isComputerOn = false;
                }
                else if (!isComputerOn && FuseBox.fuseboxPuzzleComplete == true)
                {
                    // Play switch on sound.
                    pcMeshR.material = cctv;

                    computerlight.color = Color.red;
                    computerlight.enabled = true;
                    code.SetActive(true);

                    isComputerOn = true;
                }
                else
                {
                    // Play switch on sound.
                    pcMeshR.material = darkGrey;

                    computerlight.color = Color.yellow;
                    computerlight.enabled = true;

                    code.SetActive(false);

                    isComputerOn = true;
                }
            }
        }
        // Pressing buttons on the keypad.
        else if (other.tag == "Button" && PlayerRayCast.didHitButton && !KeypadManager.isKeypadPuzzleComplete)
        {
            pressE.enabled = true;

            if (Input.GetKeyDown(KeyCode.E) && KeypadManager.playerInput.Length < 4)
            {
                // Play button sound here.

                // Send the button pressed to the keypad to add it to the current input.
                KeypadManager.AddToCode(PlayerRayCast.hitDuplicate.collider.name);
            }
        }
        else if (other.tag == "Fusebox" && PlayerRayCast.didHitSwitch && !FuseBox.fuseboxPuzzleComplete)
        {
            pressE.enabled = true;

            // Switch 1.
            if (Input.GetKeyDown(KeyCode.E) && PlayerRayCast.hitDuplicate.collider.gameObject.name == "Switch1")
            {
                if (switch1Anim.GetBool("isDown"))
                {
                    FuseBox.switch1 = false;
                    switch1Anim.SetBool("isDown", false);

                }
                else
                {
                    FuseBox.switch1 = true;
                    switch1Anim.SetBool("isDown", true);
                }
            }

            // Switch 2.
            if (Input.GetKeyDown(KeyCode.E) && PlayerRayCast.hitDuplicate.collider.gameObject.name == "Switch2")
            {
                if (switch2Anim.GetBool("isDown"))
                {
                    FuseBox.switch2 = false;
                    switch2Anim.SetBool("isDown", false);
                }
                else
                {
                    FuseBox.switch2 = true;
                    switch2Anim.SetBool("isDown", true);
                }
            }

            // Switch 3.
            if (Input.GetKeyDown(KeyCode.E) && PlayerRayCast.hitDuplicate.collider.gameObject.name == "Switch3")
            {
                if (switch3Anim.GetBool("isDown"))
                {
                    FuseBox.switch3 = false;
                    switch3Anim.SetBool("isDown", false);
                }
                else
                {
                    FuseBox.switch3 = true;
                    switch3Anim.SetBool("isDown", true);
                }
            }

            // Switch 4.
            if (Input.GetKeyDown(KeyCode.E) && PlayerRayCast.hitDuplicate.collider.gameObject.name == "Switch4")
            {
                if (switch4Anim.GetBool("isDown"))
                {
                    FuseBox.switch4 = false;
                    switch4Anim.SetBool("isDown", false);
                }
                else
                {
                    FuseBox.switch4 = true;
                    switch4Anim.SetBool("isDown", true);
                }
            }
        }
        else
        {
            pressE.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        pressE.enabled = false;
    }

    void Buffer()
    {
        handleAnim.SetBool("isUsed", false);
        handleAnim.SetBool("isLocked", false);
    }

    void OpenDoor()
    {
        doorAnim.SetBool("isOpened", true);

        // Play door opening sound here.
    }

    void CloseDoor()
    {
        doorAnim.SetBool("isOpened", false);

        // Play door closing sound here.
    }
}

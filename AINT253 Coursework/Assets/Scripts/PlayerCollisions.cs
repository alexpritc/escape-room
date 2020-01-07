using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisions : MonoBehaviour
{
    public static bool allPuzzlesComplete = false;

    public GameObject handle;
    public GameObject door;

    public GameObject computer;
    public GameObject computerScreen;
    public GameObject code;
    public Light standbyLight;
    public Light screenLight;

    public GameObject switch1;
    public GameObject switch2;
    public GameObject switch3;
    public GameObject switch4;

    public GameObject keypad;

    public GameObject fusebox;

    public Material darkGrey;
    public Material cctv;

    public Text pressE;

    public AudioSource e;

    private Animator handleAnim;
    private Animator doorAnim;

    private Animator switch1Anim;
    private Animator switch2Anim;
    private Animator switch3Anim;
    private Animator switch4Anim;

    private Rigidbody rb;

    private MeshRenderer pcMeshR;

    private AudioSource computerSwitch;
    private AudioSource computerAudio;
    private AudioSource keypadAudio;
    private AudioSource fuseboxAudio;
    private AudioSource doorAudio;
    private AudioSource doorHandleAudio;

    private bool isComputerOn = false;

    private bool isInComputerRange = false;
    private bool isInKeypadRange = false;
    private bool isInDoorRange = false;
    private bool isInFuseboxRange = false;

    private bool isFuseBoxFixed = false;

    void Start()
    {
        handleAnim = handle.GetComponent<Animator>();
        doorAnim = door.GetComponent<Animator>();

        switch1Anim = switch1.GetComponent<Animator>();
        switch2Anim = switch2.GetComponent<Animator>();
        switch3Anim = switch3.GetComponent<Animator>();
        switch4Anim = switch4.GetComponent<Animator>();

        computerAudio = computer.GetComponent<AudioSource>();
        computerSwitch = computerScreen.GetComponent<AudioSource>();
        keypadAudio = keypad.GetComponent<AudioSource>();
        fuseboxAudio = fusebox.GetComponent<AudioSource>();
        doorAudio = door.GetComponent<AudioSource>();
        doorHandleAudio = handle.GetComponent<AudioSource>();

        rb = gameObject.GetComponent<Rigidbody>();

        pcMeshR = computerScreen.GetComponent<MeshRenderer>();

        standbyLight.enabled = false;
        screenLight.enabled = false;
        code.SetActive(false);

        pressE.enabled = false;
    }

    void Update()
    {
        if (isFuseBoxFixed == false && FuseBox.fuseboxPuzzleComplete == true) {
            isFuseBoxFixed = true;
            pcMeshR.material = cctv;

            computerAudio.Play();

            standbyLight.color = Color.red;
            standbyLight.enabled = true;

            screenLight.enabled = true;

            code.SetActive(true);

            isComputerOn = true;
        }

        // Player input.
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInDoorRange)
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
                        if (!doorHandleAudio.isPlaying)
                        {
                            doorHandleAudio.Play();
                        }
                    }
                }
                else
                {
                    // Remove interactions from the door handle.
                    if (!doorHandleAudio.isPlaying)
                    {
                        doorHandleAudio.Play();
                    }
                }

                handleAnim.SetBool("isUsed", true);
                Invoke("Buffer", 0.1f);
            }
            else if (isInComputerRange)
            {
                // Play switch sound here.
                computerSwitch.Play();

                if (isComputerOn)
                {
                    computerAudio.Pause();

                    pcMeshR.material = darkGrey;

                    standbyLight.enabled = false;
                    screenLight.enabled = false;
                    code.SetActive(false);

                    isComputerOn = false;
                }
                else if (!isComputerOn && FuseBox.fuseboxPuzzleComplete == true)
                {
                
                    pcMeshR.material = cctv;

                    computerAudio.Play();

                    standbyLight.color = Color.red;
                    standbyLight.enabled = true;

                    screenLight.enabled = true;

                    code.SetActive(true);

                    isComputerOn = true;
                }
                else
                {
                    computerAudio.Pause();

                    pcMeshR.material = darkGrey;

                    standbyLight.color = Color.yellow;
                    standbyLight.enabled = true;

                    screenLight.enabled = false;

                    code.SetActive(false);

                    isComputerOn = true;
                }
            }
            else if (isInKeypadRange)
            {
                // Play keypad noise.
                keypadAudio.Play();

                // Send the button pressed to the keypad to add it to the current input.
                KeypadManager.AddToCode(PlayerRayCast.hitDuplicate.collider.name);
            }
            else if (isInFuseboxRange)
            {
                // Switch 1.
                if (Input.GetKeyDown(KeyCode.E) && PlayerRayCast.hitDuplicate.collider.gameObject.name == "Switch1")
                {
                    // Play sound.
                    fuseboxAudio.Play();

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
                    // Play sound.
                    fuseboxAudio.Play();

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

                        if (!fuseboxAudio.isPlaying)
                        {
                            fuseboxAudio.Play();
                        }
                    }
                    else
                    {
                        FuseBox.switch3 = true;
                        switch3Anim.SetBool("isDown", true);

                        if (!fuseboxAudio.isPlaying)
                        {
                            fuseboxAudio.Play();
                        }
                    }
                }

                // Switch 4.
                if (Input.GetKeyDown(KeyCode.E) && PlayerRayCast.hitDuplicate.collider.gameObject.name == "Switch4")
                {
                    // Play sound.
                    fuseboxAudio.Play();

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
                if (!e.isPlaying)
                {
                    e.Play();
                }
            }
        }

        // Check all the puzzles have been completed.
        if (KeypadManager.isKeypadPuzzleComplete)
        {
            allPuzzlesComplete = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // Attempts to use the door handle.
        if (other.tag == "Door Handle" && PlayerRayCast.didHitHandle && !doorAnim.GetBool("isOpened"))
        {
            pressE.enabled = true;

            isInDoorRange = true;
        }
        // Turning the computer on and off.
        else if (other.tag == "Computer" && PlayerRayCast.didHitComputer)
        {
            pressE.enabled = true;

            isInComputerRange = true;
        }
        // Pressing buttons on the keypad.
        else if (other.tag == "Button" && PlayerRayCast.didHitButton && !KeypadManager.isKeypadPuzzleComplete)
        {
            pressE.enabled = true;

            isInKeypadRange = true;
        }
        else if (other.tag == "Fusebox" && PlayerRayCast.didHitSwitch && !FuseBox.fuseboxPuzzleComplete)
        {
            pressE.enabled = true;

            isInFuseboxRange = true;
        }
        else
        {
            pressE.enabled = false;

            isInComputerRange = false;
            isInDoorRange = false;
            isInFuseboxRange = false;
            isInKeypadRange = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        pressE.enabled = false;

        isInComputerRange = false;
        isInDoorRange = false;
        isInFuseboxRange = false;
        isInKeypadRange = false;
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
        doorAudio.Play();
    }
}

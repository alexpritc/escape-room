using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject model;

    public static float speed = 10f;

    private Vector3 velocity;
    private Vector3 down;
    private Vector3 move;

    private Rigidbody rb;
    private Animator anim;
    private AudioSource audioSource;

    private Transform playerTransform;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = model.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();

        playerTransform = transform;
    }

    // Update is called once per frame.
    // Player input.
    void Update()
    {
        // Get movement input.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x == 0 && z == 0)
        {
            anim.SetBool("isWalking", false);
            audioSource.Pause();
        }
        else
        {
            anim.SetBool("isWalking", true);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        // Local movement according to player's rotation.
        move = playerTransform.right * x + playerTransform.forward * z;
    }

    // Physics.
    void FixedUpdate()
    {
        // Play footstep sounds here.
        rb.MovePosition(rb.position + (move * speed * Time.deltaTime));
    }
}

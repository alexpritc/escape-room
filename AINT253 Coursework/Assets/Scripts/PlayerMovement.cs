using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 15f;

    public GameObject human;

    private Animator playerAnim;
    private Rigidbody rb;

    void Start()
    {
        playerAnim = human.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (x == 0 && z == 0)
        {
            playerAnim.SetBool("isWalking", false);
        }
        else
        {
            playerAnim.SetBool("isWalking", true);
        }

        // Local movement according to player's rotation.
        Vector3 move = transform.right * x + transform.forward * z;

        rb.MovePosition(rb.position + (move * speed * Time.deltaTime));

        // Play footstep sounds here.
    }
}

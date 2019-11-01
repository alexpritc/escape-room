﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 15f;

    private Rigidbody rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame.
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Local movement according to player's rotation.
        Vector3 move = transform.right * x + transform.forward * z;

        rb.MovePosition(rb.position + (move * speed * Time.deltaTime));
    }
}

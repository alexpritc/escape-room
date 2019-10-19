using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float mouseSensitivity = 3f;

    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();

    }

    void Update()
    {
        // Calculate movement velocity as a 3D vector.
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMove;
        Vector3 moveVertical = transform.forward * zMove;

        // Final movment vector.
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        // Apply movement.
        motor.Move(velocity);

        // Calculate rotation as a 3D vector (turning around).
        float yRotation = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRotation, 0f) * mouseSensitivity;

        // Apply rotation.
        motor.Rotate(rotation);

        // Calculate camera rotation as a 3D vector (looking around).
        float xRotation = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRotation, 0f, 0f) * mouseSensitivity;

        // Apply camera rotation.
        motor.RotateCamera(cameraRotation);

    }
}

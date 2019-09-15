using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerController : MonoBehaviour
{
    public Joystick moveInput; // Joystick input for moving
    public Joystick aimInput; // Joystick input for aiming

    float aimAngle;

    [Header("Camera")]
    public Camera playerCamera; // Camera that views player
    public Vector3 relativePosition; // Camera's position relative to player
    //public float rotateSpeed;

    [Header("Movement")]
    public float movementSpeed = 10;
    Vector2 movementInput;
    Vector3 movementValue;
    Rigidbody rb;
    bool canMove;




    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativeForward = Vector3.forward; // Specifies direction to rotate player relative to
        Vector2 from = new Vector2(relativeForward.x, relativeForward.z);

        Vector2 aimData = aimInput.Direction.normalized; // Normalises player aiming direction
        if (aimInput.Direction != Vector2.zero) // If aimInput joystick is being used
        {
            aimAngle = -Vector2.SignedAngle(from, aimData); // Specifies angle to rotate the player towards
            transform.rotation = Quaternion.Euler(0, aimAngle, 0); // Rotates the player towards said angle
        }

        movementInput = moveInput.Direction; // Obtains movement input
        if (movementInput.magnitude > 1)
        {
            movementInput.Normalize(); // Normalises movementInput to prevent from going past the intended movement speed
        }
        movementValue = new Vector3(movementInput.x * movementSpeed, 0, movementInput.y * movementSpeed); // Turns input data into a 3D direction, multiplied by movementSpeed


        CameraFollow(); // The code in the CameraFollow function is broken.
    }

    void CameraFollow()
    {

        playerCamera.transform.position = transform.position + relativePosition; // Moves camera to match Vector3 relativePosition, relative to the player

        //playerCamera.transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Rotate") * rotateSpeed * Time.deltaTime));
    }


    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movementValue * Time.deltaTime); // Moves player

    }
}

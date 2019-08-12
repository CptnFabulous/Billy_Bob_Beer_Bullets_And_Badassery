using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerController : MonoBehaviour
{
    public Joystick moveInput;
    public Joystick aimInput;

    float aimAngle;

    [Header("Camera")]
    public Camera playerCamera; // Camera that views player
    public Vector3 relativePosition;
    public float rotateSpeed;

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
        Vector3 relativeForward = Vector3.forward;
        Vector2 from = new Vector2(relativeForward.x, relativeForward.z);

        Vector2 aimData = aimInput.Direction.normalized;
        if (aimInput.Direction != Vector2.zero)
        {
            aimAngle = -Vector2.SignedAngle(from, aimData);
            rb.MoveRotation(Quaternion.Euler(0, aimAngle, 0));
        }

        movementInput = moveInput.Direction;
        if (movementInput.magnitude > 1)
        {
            movementInput.Normalize();
        }
        movementValue = new Vector3(movementInput.x * movementSpeed, 0, movementInput.y * movementSpeed);


        CameraFollow(); // The code in the CameraFollow function is broken.
    }

    void CameraFollow()
    {

        playerCamera.transform.position = transform.position + relativePosition;

        //playerCamera.transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Rotate") * rotateSpeed * Time.deltaTime));
    }


    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movementValue * Time.deltaTime);

    }
}

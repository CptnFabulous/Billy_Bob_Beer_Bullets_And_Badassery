using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [Header("Camera")]
    public Camera playerCamera;
    public Vector3 relativePosition;
    //Vector3 relativeUp;

    [Header("Aiming")]
    public Joystick rightArmInput;
    public Joystick leftArmInput;
    public GameObject rightArmPivot;
    public GameObject leftArmPivot;

    float rightAimAngle;
    float leftAimAngle;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


        AimArms();

        CameraFollow();
    }

    void AimArms()
    {
        Vector3 relativeForward = Vector3.forward;
        Vector2 from = new Vector2(relativeForward.x, relativeForward.z);
        

        Vector2 rightArmData = rightArmInput.Direction.normalized;
        if (rightArmInput.Direction != Vector2.zero)
        {
            rightAimAngle = -Vector2.SignedAngle(from, rightArmData);
            //rb.MoveRotation(Quaternion.Euler(0, rightAimAngle, 0));
        }

        Vector2 leftArmData = leftArmInput.Direction.normalized;
        if (leftArmInput.Direction != Vector2.zero)
        {
            leftAimAngle = Vector2.SignedAngle(from, leftArmData);
            //rb.MoveRotation(Quaternion.Euler(0, leftAimAngle, 0));
        }

        print("Left aim angle = " + leftAimAngle + ", right aim angle = " + rightAimAngle);

        //rb.MoveRotation(Quaternion.Euler(0, Mathf., 0));

        float playerAngle = (Mathf.Max(leftAimAngle, rightAimAngle) + Mathf.Min(leftAimAngle, rightAimAngle)) / 2;

        rb.MoveRotation(Quaternion.Euler(0, playerAngle, 0));



    }

    void CameraFollow()
    {

        playerCamera.transform.position = transform.position + relativePosition;

        //playerCamera.transform.Rotate(new Vector3(0, 0, -Input.GetAxis("Rotate") * rotateSpeed * Time.deltaTime));
    }
}

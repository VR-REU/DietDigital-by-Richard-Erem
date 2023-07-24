using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 200.0f;
    private float rotationX = 0;
    private float rotationY = 0;
    public MouseLookWithButton mouselook;

    void Update()
    {
        if (mouselook.enabled)
        {
            // This is to calculate movement of camera (Player)
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            // This ensures that movement is always in the direction of the camera
            movement = transform.TransformDirection(movement);
            movement = movement * moveSpeed * Time.deltaTime;
            transform.position = transform.position + movement;

            // This is to rotate the camera according to mouse input
            rotationX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            rotationY += Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            rotationY = Mathf.Clamp(rotationY, -90, 90);
            transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
            transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookWithButton : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private bool mouseDown = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            mouseDown = false;
        }
        if (mouseDown)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            yRotation += mouseX;
            yRotation = yRotation % 360f;

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}

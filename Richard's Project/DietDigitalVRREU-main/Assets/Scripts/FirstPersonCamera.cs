using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 100.0f;
    public Transform player;

    private float xRotation = 0.0f;
    private float yRotation = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Follow the player's position with an offset to position the camera at head height
        float headHeightOffset = 0.7f; // Adjust this value as needed
        Vector3 headPosition = player.position + new Vector3(0, headHeightOffset, 0);
        transform.position = headPosition;

        if (Input.GetMouseButton(0)) // 0 represents the left mouse button
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            yRotation += mouseX;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera mainCamera;
    private Animator animator;
    private Vector3 initialCameraForward;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (mainCamera == null)
        {
            // Use the main camera if no specific camera is assigned
            mainCamera = Camera.main;
        }

        // Store the initial camera forward direction
        initialCameraForward = mainCamera.transform.forward;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Update animation
        animator.SetFloat("Horizontal", moveHorizontal);
        animator.SetFloat("Vertical", moveVertical);

        // Calculate the direction vector relative to the camera's forward direction
        Vector3 cameraForward = mainCamera.transform.forward;
        cameraForward.y = 0f; // Ignore vertical component
        cameraForward.Normalize();

        Vector3 direction;
        
        if (moveVertical < 0f)
        {
            // Moving backward
            direction = moveVertical * -cameraForward;
        }
        else
        {
            // Moving forward or sideways
            direction = moveHorizontal * mainCamera.transform.right + moveVertical * cameraForward;
        }

        if (direction.magnitude > 0.1f)
        {
            // Rotate the character to face the direction of movement
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        // Move the character using Transform component
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}

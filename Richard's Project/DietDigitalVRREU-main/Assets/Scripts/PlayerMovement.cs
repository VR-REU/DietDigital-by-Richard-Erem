using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1.4F; // Adjust this value to change the speed
    public float rotationSpeed = 700.0F; // Adjust to make turning faster or slower
    public float initialHeight = 0.65f;  // slightly above the ground

    private CharacterController controller;
    private Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // New movement code
        Vector3 moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0.0f;

        // Rotate the character to face the direction of movement
        if (moveDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        controller.SimpleMove(moveDirection * speed);

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            animator.SetBool("IsWalking", true);
        }
        else 
        {
            animator.SetBool("IsWalking", false);
        }
    }
}

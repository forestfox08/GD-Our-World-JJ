using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float Speed = 6f;
    float JumpForce = 5f;
    float Sensitivity = 5f;

    private Rigidbody rb;
    private bool isGrounded = true;
    void Update()
    {
        // Mouse Rotation
        float mouseX = Input.GetAxis("Mouse X");
        Quaternion deltaRotation = Quaternion.Euler(0, mouseX * Sensitivity, 0);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 8.5f;
        }
        else
        {
            Speed = 6f;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Gravity is automatically handled by Rigidbody, so we don’t need to manually add it.

        // Movement
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        moveDirection = moveDirection.normalized * Speed;

        
        Vector3 velocity = moveDirection;
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

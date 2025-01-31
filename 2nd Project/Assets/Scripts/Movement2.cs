using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    float Speed = 6;

    float jumpForce = 5f;

    float sensitivity = 5;

    float gravity = -9.81f;
    
    float velocityY = 0f;

    public GameObject PlayerModel;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Gravity

        velocityY += gravity * Time.deltaTime;

        transform.Translate(Vector3.up * velocityY * Time.deltaTime);


        if (transform.position.y <= 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            velocityY = 0;
        }

        // Movement Mechanics! :D

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            UnlockCursor();
        }

        if(Input.GetMouseButton(0))
        {
            LockCursor();
        }

        void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void UnlockCursor()
        {
            Cursor.lockState= CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Speed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Speed * Time.deltaTime;
            ;
        }
        
        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(0, mouseX * sensitivity, 0);

        //Sprinting for dummies :P

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Speed = 8.5f;
        }
        else
        {
            Speed = 6;
        }

        // JUMPING!

        if (Input.GetKey(KeyCode.Space) && velocityY == 0)
        {
          velocityY = jumpForce;  
        }


        }
    }
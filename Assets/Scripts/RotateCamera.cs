using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 10; // The speed at which the camera rotates

    void Update()
    {
        // Check if the right mouse button is pressed
        if (Input.GetMouseButton(1))
        {
            // Lock cursor 
            //Cursor.lockState = CursorLockMode.Locked;
            // Get the amount to rotate the camera by
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed;

            // Rotate the camera
            transform.Rotate(-rotationY, rotationX, 0);
        } else if (Input.GetMouseButton(2))
        {
            float moveY = Input.GetAxis("Mouse Y") * rotationSpeed;
            float moveX = Input.GetAxis("Mouse X") * rotationSpeed;

            // Do something to move camera up and left/right
        }
    }
}
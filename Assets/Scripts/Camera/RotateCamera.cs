using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateCamera : MonoBehaviour
{
    public bool is2D;

    public float rotationSpeed = 10; // The speed at which the camera rotates
    public float scrollSpeed = 10.0f;
    public float translateXSpeed = 1;
    public float translateYSpeed = 1f;
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

            // Tilt the camera


            
            if (is2D)
            {
                transform.Rotate(0, rotationX, 0);
            }
            else
            {
                transform.Rotate(-rotationY, rotationX, 0);
            }

            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
            
           
        } else if (Input.GetMouseButton(2))
        {
            float moveX = Input.GetAxis("Mouse X") * translateXSpeed;   // Sets adjustable move speed that can be used in unity environment.
            float moveY = Input.GetAxis("Mouse Y") * translateYSpeed;
            transform.position += transform.up * -moveY;    // Uses inverted Y scroll amount for flipped controls.
            transform.position += transform.right * -moveX; // Calculates movement amount by multiplying scroll amount by speed specified.
        } 

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        transform.position += transform.forward * scroll * scrollSpeed * Time.deltaTime;

    }
}
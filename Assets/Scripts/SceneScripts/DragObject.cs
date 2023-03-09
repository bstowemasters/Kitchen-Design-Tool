using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;
    private Vector3 newWorldCoords;

    private Rigidbody rb;
    private bool objCollision = false;

    //private Camera mainCam;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        GameObject floor = GameObject.FindGameObjectWithTag("Floor");
        Physics.IgnoreCollision(GetComponent<Collider>(), floor.GetComponent<Collider>());

    }

    private void OnMouseDown()
    {
        objCollision = false;   // Resets collision detection after object has collided.

        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;  // Selects main camera and gets z pos

        // calculates the mouse offset from the camera and object
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // Stores x & y coordinates of mouse
        Vector3 mousePoint = Input.mousePosition;

        // Stores the z position in variable.
        mousePoint.z = mouseZCoord;

        // returns the mouse position
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        if (objCollision == false)
        {
            newWorldCoords = transform.position;                        // Starts moving object.
            newWorldCoords.x = GetMouseWorldPos().x + mouseOffset.x;    // Shows the object at the correct screen position in the scene.
            newWorldCoords.z = GetMouseWorldPos().y - mouseOffset.y;
                        
            //newWorldCoords.y = 0.000000001f;                            // Resets y position to floor.
            
            transform.position = newWorldCoords;                        // Updates ovjects position.
        } else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;            // Stops the object moving inside another.

        }


    }

    private void OnCollisionEnter(Collision collision)                  // Runs when collision is detected (ignoring floor)
    {
        if (gameObject != null && rb != null)
        {
            objCollision = true;
        }
    }

}

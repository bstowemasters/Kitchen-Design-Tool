using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragObject : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;
    private Vector3 newWorldCoords;

    private Rigidbody rb;
    public bool objCollision = false;
    private bool onlyFreezeX = false;
    private bool onlyFreezeY = false;
    public Vector3 currentPos;

    //private Camera mainCam;

    private void Start()
    {
        

        rb = gameObject.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

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

        if (!objCollision)
        {
            newWorldCoords = transform.position;                        // Starts moving object.
            newWorldCoords.x = GetMouseWorldPos().x + mouseOffset.x;    // Shows the object at the correct screen position in the scene.
            newWorldCoords.z = GetMouseWorldPos().y - mouseOffset.y;
                        
            //newWorldCoords.y = 0.000000001f;                            // Resets y position to floor.
            
            transform.position = newWorldCoords;                        // Updates ovjects position.
        } else if (onlyFreezeX)
        {
            newWorldCoords = transform.position;                        // Starts moving object.
            newWorldCoords.x = GetMouseWorldPos().x + mouseOffset.x;
            transform.position = newWorldCoords;
        } else if (onlyFreezeY)
        {
            newWorldCoords = transform.position;                        // Starts moving object.
            newWorldCoords.z = GetMouseWorldPos().y + mouseOffset.y;
            transform.position = newWorldCoords;
        }

        else
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
        if (collision.gameObject.CompareTag("Wall"))
        {
            onlyFreezeX = true; // Could be used to only stop collisions on z axis when hitting wall.
        }
        if (collision.gameObject.CompareTag("Cabinet"))
        {
            onlyFreezeY = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}

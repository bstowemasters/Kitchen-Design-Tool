using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DragObject : MonoBehaviour
{
    private Vector3 mouseOffset;
    private Vector3 newWorldCoords;
    public Vector3 currentPos;

    private Rigidbody rb;

    private float mouseZCoord;

    private bool isDrag = false;
    public bool objCollision = false;
    private bool onlyFreezeX = false;
    private bool onlyFreezeY = false;





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

        mouseZCoord = Camera.main.WorldToViewportPoint(gameObject.transform.position).z;  // Selects main camera and gets z pos

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

    private void OnMouseDrag() {

        isDrag = true;
        


    }

    private void OnMouseUp()
    {
        isDrag = false;
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

        //Debug collision direction

        //// Get the first contact point of the collision
        //ContactPoint contact = collision.contacts[0];

        //// Get the normal vector of the contact point
        //Vector3 normal = contact.normal;

        //// Determine the direction of the collision
        //if (normal == Vector3.up)
        //{
        //    Debug.Log("Collision came from below");
        //}
        //else if (normal == Vector3.down)
        //{
        //    Debug.Log("Collision came from above");
        //}
        //else if (normal == Vector3.left)
        //{
        //    Debug.Log("Collision came from the right");
        //}
        //else if (normal == Vector3.right)
        //{
        //    Debug.Log("Collision came from the left");
        //}
        //else if (normal == Vector3.forward)
        //{
        //    Debug.Log("Collision came from behind");
        //}
        //else if (normal == Vector3.back)
        //{
        //    Debug.Log("Collision came from in front");
        //}
    }

    private void FixedUpdate()
    {
        if (isDrag == true)
        {


            if (!objCollision)
            {
                newWorldCoords = transform.position;                        // Sets new position.
                newWorldCoords.x = GetMouseWorldPos().x + mouseOffset.x;    // Sets the new x and y coordinates using mouse input
                newWorldCoords.z = GetMouseWorldPos().y - mouseOffset.y;

                newWorldCoords = new Vector3(Mathf.Round(newWorldCoords.x * 10) / 10, newWorldCoords.y, Mathf.Round(newWorldCoords.z * 10) / 10);

                //newWorldCoords.y = 0.000000001f;                            // Resets y position to floor.

                transform.position = newWorldCoords;                        // Updates objects position.
            }
            else if (onlyFreezeX)
            {
                newWorldCoords = transform.position;                        // Starts moving object.
                newWorldCoords.x = GetMouseWorldPos().x + mouseOffset.x;
                transform.position = newWorldCoords;
            }
            else if (onlyFreezeY)
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
    }
}

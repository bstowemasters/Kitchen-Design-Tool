using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;
    private Vector3 newWorldCoords;

    //private Camera mainCam;

    private void OnMouseDown()
    {
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
        newWorldCoords = transform.position;
        newWorldCoords.x = GetMouseWorldPos().x + mouseOffset.x;    // Shows the object at the correct screen position in the scene.
        newWorldCoords.z = GetMouseWorldPos().y - mouseOffset.y;
        transform.position = newWorldCoords;                        // Updates ovjects position.
    }
}

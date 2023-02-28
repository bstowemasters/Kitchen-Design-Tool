using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZCoord;
    private Vector3 newWorldCoords;

    private void OnMouseDown()
    {
        mouseZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // calculates the mouse offset from the object
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private Vector3 GetMouseWorldPos()
    {
        // X,y pixel coordinates
        Vector3 mousePoint = Input.mousePosition;

        mousePoint.z = mouseZCoord;


        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private void OnMouseDrag()
    {
        newWorldCoords = transform.position;
        newWorldCoords.x = GetMouseWorldPos().x + mouseOffset.x;
        newWorldCoords.z = GetMouseWorldPos().y + mouseOffset.y;
        transform.position = newWorldCoords;
    }
}

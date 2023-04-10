using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CreateWall : MonoBehaviour
{

    public Camera TopCam;
    public Button startDrawBtn;

    public GameObject wallStartPos;
    public GameObject wallEndPos;
    public GameObject wall;
    public GameObject wallPrefab;

    BoxCollider wallCollider;

    TextMeshProUGUI btnText;


    bool drawing;
    bool drawMode;
    // Start is called before the first frame update
    void Start()
    {
        startDrawBtn.onClick.AddListener(checkDrawMode); // Listen for a button press. Run create hologram when clicked.
        Camera.main.enabled = false;

        wallCollider = wallPrefab.GetComponentInChildren<BoxCollider>();
        btnText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void checkDrawMode()
    {
        if (drawMode)
        {
            drawMode = false;
            btnText.text = "Start Drawing";
            Camera.main.enabled = true;
            TopCam.enabled = true;
            TopCam.AddComponent<AudioListener>();

        }
        else
        {
            drawMode = true;
            btnText.text = "Stop";
            Camera.main.enabled = false;
            DestroyImmediate(TopCam.GetComponent<AudioListener>()); 

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (drawMode)
        {
            checkStartDrawing();
        }
        
    }

    void checkStartDrawing()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            startDrawingPos();
        } else if (Input.GetMouseButtonUp(0))
        {
            stopDrawingPos();
        } else
        {
            if (drawing)
            {
                drawWall();
            }
        }
    }

    void startDrawingPos()
    {
        drawing = true;
        wallStartPos.transform.position = ScreenToWorldPoint(); // Set the pillar to the start pos.
        wall = Instantiate(wallPrefab, wallStartPos.transform.position, Quaternion.identity);   // Stop rotation and instantiate wall prefab, later to be resized
    }

    void stopDrawingPos()
    {
        drawing = false;
        wallEndPos.transform.position = ScreenToWorldPoint();
    }

    void drawWall()
    {
        wallEndPos.transform.position = ScreenToWorldPoint()/10 * 10;
        updateWallSize();
    }

    void updateWallSize()
    {
        wallStartPos.transform.LookAt(wallEndPos.transform.position);   // Rotate the walls to face eachother.
        wallEndPos.transform.LookAt(wallStartPos.transform.position);

        float distance = Vector3.Distance(wallStartPos.transform.position, wallEndPos.transform.position);

        wall.transform.position = wallStartPos.transform.position + distance / 2 * wallStartPos.transform.forward;  // /2 allows for the scaling to perform from the center of the two walls.
        wall.transform.rotation = wallStartPos.transform.rotation;  // Rotate the middle wall correctly.
        wall.transform.localScale = new Vector3(wall.transform.localScale.x, wall.transform.localScale.y, distance);

        wallCollider.size = wall.transform.localScale;  // Adds the same sizing to the collider to objects can detect collision properly.

    }

    Vector3 ScreenToWorldPoint()
    {
        Ray ray = TopCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            return hit.point;   // Return where the mouse point hits the 3D scene
        }

        return Vector3.zero;    // Fixes unity bug where not all paths return value.
    }

}

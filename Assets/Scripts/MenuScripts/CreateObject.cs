using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class CreateObject : MonoBehaviour
{

    public GameObject unitPrefab;
    public Button button;
    private GameObject hologram;
    public GameObject units; // Test to set parent for all prefab under cabinets

    private Rigidbody rb;

    private void Start()
    {
        units = GameObject.Find("Cabinets");    // Where to put the child elements (new cabs)
        button.onClick.AddListener(CreateHologram); // Listen for a button press. Run create hologram when clicked.
    }

    private void CreateHologram()
    {
        GlobalAccessScripts.allowSelect = false;
        hologram = Instantiate(unitPrefab); // Creates a new instance of the gameObject.
        hologram.SetActive(true);           // Sets the prefabs state to active, so the prefab can be seen.
        hologram.transform.SetParent(units.transform);


    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition; // Store the current mouse position in a vector.
        mousePos.z = Camera.main.nearClipPlane + 3; // Store the mouse position z axis as the camera's z position + 3
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);    // Store the world position in a separate vector to place the object.



        

        if (hologram != null)   // Checks if the prefab has been set.
        {
            worldPos.z = Camera.main.nearClipPlane - 3 + mousePos.y / 100;
            worldPos = new Vector3(Mathf.Round(worldPos.x * 10) / 10, worldPos.z, Mathf.Round(worldPos.y * 10) / 10);

            if (hologram.CompareTag("Wall Appliance"))
            {
                worldPos.y = 1.7f;
            } else if (hologram.CompareTag("Base Appliance"))
            {
                worldPos.y = 0.33f;
            }
            else
            {
                worldPos.y = Camera.main.nearClipPlane - 0.3f;     // Eliminates the hover effect from the y mouse point

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                hologram.transform.Rotate(Vector3.forward, 450);
            }
            
            hologram.transform.position = worldPos; // Hovers the prefab over the current mouse pos.

        }


        if (Input.GetMouseButtonDown(0) && hologram != null)    // Checks if the prefab has been set and the left mouse button is clicked.
        {

            //if (hologram.CompareTag("Wall Appliance"))
            //{
            //    worldPos.y = 1.7f;
            //}


            hologram.transform.position = worldPos;             // Shows the newly placed object at the position it was placed.

  
            hologram = null;                                    // Clears the selected prefab.
            GlobalAccessScripts.allowSelect = true;             // Clears the blocker that stops mouse presses.
        }

    }

}
 
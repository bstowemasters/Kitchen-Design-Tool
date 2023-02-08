using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverObject : MonoBehaviour
{

    public GameObject unitPrefab;
    public Button button;
    private GameObject hologram;

    private void Start()
    {
        button.onClick.AddListener(CreateHologram); // Listen for a button press.
    }

    private void CreateHologram()
    {
       
        hologram = Instantiate(unitPrefab); // Creates a new instance of the gameObject.
        hologram.SetActive(true);           // Makes sure you can see it.

    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition; // Store the current mouse position in a vector.
        mousePos.z = Camera.main.nearClipPlane + 3; // Store the mouse position z axis as the camera's z position + 3
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);    // Store the world position in a separate vector to place the object.

        

        if (hologram != null)   // Checks if the prefab has been set.
        {
            worldPos.z = Camera.main.nearClipPlane + 3 - mousePos.y / 100;
            worldPos.y = Camera.main.nearClipPlane - 0.25f;
            hologram.transform.position = worldPos; // Hovers the prefab over the current mouse pos.

        }


        if (Input.GetMouseButtonDown(0) && hologram != null)    // Checks if the prefab has been set and the left mouse button is clicked.
        {
            hologram.transform.position = worldPos;             // Shows the newly placed object at the position it was placed.
            hologram = null;                                    // Clears the selected prefab.
        }

    }

}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using JetBrains.Annotations;

public class Hologram : MonoBehaviour
{
    public GameObject prefab; // The prefab to instantiate
    public GameObject hologram; // The current hologram object


    void OnBeginDrag(PointerEventData eventData)
    {
        // The object has begun being dragged

        // Instantiate the prefab at the current mouse position
        hologram = Instantiate(prefab, Input.mousePosition, Quaternion.identity);

        // Set the position of the hologram object
        hologram.transform.position = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
            
        void OnEndDrag(PointerEventData eventData)
        {
            // Destroy the hologram object
            Destroy(hologram);
            prefab = Instantiate(prefab, Input.mousePosition, Quaternion.identity);
            prefab.transform.position = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        }

    }

    
}

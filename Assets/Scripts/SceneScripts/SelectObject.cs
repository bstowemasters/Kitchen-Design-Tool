using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectObject : MonoBehaviour
{
    private Renderer[] renderer;
    private Material[] origMaterials;

    private bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isSelected)
            {
                selectObject();
            }
            else
            {
                deselectObject();
            }
        }
    }


    private void selectObject()
    {
        foreach (var rend in renderer)
        {
            rend.material.color = Color.green;

        }
        isSelected = true;
        Debug.Log("Selected");
    }

    private void deselectObject()
    {
        foreach (var rend in renderer)
        {
            rend.material.color = Color.white;
        }
        isSelected = false;
        Debug.Log("De Selected");
    }

    private void OnMouseDown()
    {

    }

    private void OnMouseUp()
    {

    }

}

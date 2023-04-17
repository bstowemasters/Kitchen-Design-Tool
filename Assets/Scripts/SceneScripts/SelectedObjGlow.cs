using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//[RequireComponent(typeof(Renderer))]
public class SelectedObjGlow : MonoBehaviour
{
    public GameObject selectedObject;
    private Renderer currRend;
    private Material colour;

    private bool isSelected;


    void Start()
    {
        if(selectedObject.GetComponent<MeshRenderer>() == null)
        {
            selectedObject.AddComponent<MeshRenderer>();
        }

        currRend = selectedObject.GetComponent<MeshRenderer>();

        colour = currRend.material;

    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.gameObject == selectedObject)
                    {
                        Debug.Log("Prefab clicked!: ");
                        if (isSelected == false)
                        {
                            currRend.material.EnableKeyword("_EMISSION");
                            colour.color = Color.red;
                            isSelected = true;
                        }
                        else
                        {
                            currRend.material.DisableKeyword("_EMISSION");
                            isSelected = false;
                        }
                    }
                }
            }

        }

        // Detect if the game object is clicked
        


    }

}

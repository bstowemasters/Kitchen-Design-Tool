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
    private Material origMaterial;

    private bool isSelected;


    void Start()
    {
        if(selectedObject.GetComponent<MeshRenderer>() == null)
        {
            selectedObject.AddComponent<MeshRenderer>();
        }

        currRend = selectedObject.GetComponent<MeshRenderer>();

        colour = currRend.material;
        origMaterial = colour;


    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GlobalAccessScripts.allowSelect == false)   // Check if program is doing anything else
        {

        }else
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
                                colour.color = origMaterial.color;

                                currRend.material.DisableKeyword("_EMISSION");
                                isSelected = false;
                            }
                        }
                    }
                }

            }
        }
        

        // Detect if the game object is clicked
        


    }
    

}

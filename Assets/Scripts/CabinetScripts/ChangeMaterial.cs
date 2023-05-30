using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMaterial : MonoBehaviour
{
    public Button changeMaterialBtn;    // Selects which button triggers script.
    public Material newMaterial;        // Holds new worktop/door material to replace existing.
    public bool isWorktop;    // check which object to change material. (used to reduce replicated code)
    public bool isDoor;
    public bool isHandle;
    public bool isFloor;
    public bool isWall;
    public new Renderer renderer;        // Creates renderer object to change material.

    private void Start()
    {
        changeMaterialBtn.onClick.AddListener(ReplaceMaterial); // Listen for a button press. Run change worktop function when clicked
    }

    public void ReplaceMaterial()
    {
        var cabinets = GameObject.FindGameObjectsWithTag("Cabinet");    // Finds all cabinets by searching tag name.
        var flooring = GameObject.FindGameObjectsWithTag("Floor");
        var walls = GameObject.FindGameObjectsWithTag("Wall");

        if (isFloor)
        {
            foreach (var floorPart in flooring)
            {
                if (floorPart.GetComponent<Renderer>() == null)
                {
                    floorPart.AddComponent<Renderer>();
                }
                else
                {
                    renderer = floorPart.GetComponent<Renderer>();
                    renderer.material = newMaterial;
                }
            }
        }
        if (isWall) 
        {
            foreach (var wall in walls)
            {
                if(wall.GetComponent<Renderer>() == null)
                {
                    wall.AddComponent<Renderer>();
                }
                else
                {
                    renderer = wall.GetComponent<Renderer>();
                    renderer.material = newMaterial;
                }
            }
        }

        foreach (var cabinet in cabinets)
        {
            var cabinetComponents = cabinet.GetComponentsInChildren<Transform>();

            foreach (var component in cabinetComponents)    // Searches for all elements with the cabinet tag name & iterates through the list.
            {

                if (isWorktop)
                {
                    if (component.CompareTag("Worktop"))    // Searches for elements with tag name worktop to find the worktop element.
                    {
                        renderer = component.GetComponent<Renderer>();  // Selects the first renderer component on the object(/s component)

                        if (renderer != null)   // Checks to see if it exists.
                        {
                            renderer.material = newMaterial;    // Changes the material with the new material specified
                        }
                    }
                    
                }
                else if (isDoor)    // Checks to see if the script should change the doors instead of worktops.
                {
                    if (component.CompareTag("Doors"))      // Searches for elements with the Doors tag to find the door fronts and plinths.
                    {
                        renderer = component.GetComponent<Renderer>();

                        if (renderer != null)
                        {
                            renderer.material = newMaterial;
                        }
                    }
                }
                else if (isHandle)
                {
                    if (component.CompareTag("Handle"))      // Searches for elements with the Doors tag to find the door fronts and plinths.
                    {
                        renderer = component.GetComponent<Renderer>();

                        if (renderer != null)
                        {
                            renderer.material = newMaterial;
                        }
                    }
                }




            }

        }


    }

}
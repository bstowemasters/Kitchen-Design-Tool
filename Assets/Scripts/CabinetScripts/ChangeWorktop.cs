using System;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWorktop : MonoBehaviour
{
    public Button changeMaterialBtn;    // Selects which button triggers script.
    public Material newMaterial;        // Holds new worktop/door material to replace existing.
    public bool isWorktop;    // Boolean that checks to change the worktop or door material. (used to reduce replicated code)
    Renderer renderer;        // Creates renderer object to change material.

    private void Start()
    {
        changeMaterialBtn.onClick.AddListener(ChangeMaterial); // Listen for a button press. Run change worktop function when clicked
    }

    public void ChangeMaterial()
    {
        var cabinets = GameObject.FindGameObjectsWithTag("Cabinet");    // Finds all cabinets by searching tag name.

        foreach (var cabinet in cabinets)
        {
            var cabinetComponents = cabinet.GetComponentsInChildren<Transform>();

            foreach (var component in cabinetComponents)    // Searches for all elements with the cabinet tag name & iterates through the list.
            {

                if (isWorktop == true)
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
                else    // Checks to see if the script should change the doors instead of worktops.
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

                

                
            }
            

        }
    }


}
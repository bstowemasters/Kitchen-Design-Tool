using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallColour : MonoBehaviour
{
    // Start is called before the first frame update
    public Button colourBtn;
    public GameObject wall;
    public Color newColour;

    // Objects to reset material
    public Material newMaterial;
    public  new Renderer renderer;

    private void Start()
    {
        colourBtn.onClick.AddListener(changeWallColour);
    }

    private void changeWallColour()
    {

        var walls = GameObject.FindGameObjectsWithTag("Wall");

        foreach (var wall in walls)
        {
            if (wall.GetComponent<Renderer>() == null)
            {
                wall.AddComponent<Renderer>();
            }
            else
            {
                renderer = wall.GetComponent<Renderer>();
                renderer.material = newMaterial;
                wall.GetComponent<Renderer>().material.color = newColour;
            }
        }



        
    }
}

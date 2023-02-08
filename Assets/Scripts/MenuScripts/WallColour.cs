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

    private void Start()
    {
        colourBtn.onClick.AddListener(changeWallColour);
    }

    private void changeWallColour()
    {
        wall.GetComponent<Renderer>().material.color = newColour;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


//[RequireComponent(typeof(Renderer))]
public class SelectedObjGlow : MonoBehaviour
{
    private Renderer currRend;
    private bool isSelected;
    // private Color origColour;


    // Start is called before the first frame update
    void Start()
    {
        currRend = GetComponent<Renderer>();
        //origColour = currRend.material.color;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (isSelected)
            {
                //currRend.material.color = origColour; - could be used to change colour instead
                currRend.material.DisableKeyword("_EMISSION");
                isSelected = false;
            }
            else
            {
                //currRend.material.color = Color.red;
                currRend.material.EnableKeyword("_EMISSION");
                isSelected = true;
            }
        }

    }

}

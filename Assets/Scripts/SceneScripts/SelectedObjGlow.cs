using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


//[RequireComponent(typeof(Renderer))]
public class SelectedObjGlow : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject selectedObject;

    private bool isSelected;
    private bool dragging;

    private Material[] origMaterials;
    private Material glow;


    void Start()
    {
        MeshRenderer[] meshRend = GetComponentsInChildren<MeshRenderer>();
        origMaterials = new Material[meshRend.Length];

        for (int i = 0; i < meshRend.Length; i++)
        {
            origMaterials[i] = meshRend[i].material;
        }
    }

    private void Update()
    {
        if (dragging && Input.GetMouseButtonUp(0))
        {
            disableGlow();
        }
    }

    private void OnMouseDown()
    {
        // Detect if the game object is clicked
        if (!dragging && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == selectedObject)
                {
                    Debug.Log("Prefab clicked!: ");
                    if (!isSelected)
                    {

                        EnableGlow();
                    }
                    else
                    {

                        disableGlow();

                    }
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragging = true;
        disableGlow();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;

    }

    private void EnableGlow() 
    {
        MeshRenderer[] meshRend = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRend)
        {
            meshRenderer.material = glow;
        }

        isSelected = true;
    }
    private void disableGlow()
    {
        MeshRenderer[] meshRend = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < meshRend.Length; i++)
        {
            meshRend[i].material = origMaterials[i];
        }
        isSelected = false;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.RendererUtils;

public class SelectProduct : MonoBehaviour
{
    private GameObject selectedProduct;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                selectedProduct = hit.transform.gameObject;
                ReduceOpacity();
                Debug.Log("Selected Object: " + selectedProduct.name);
            }
        }
    }

    private void ReduceOpacity()
    {
        Material material = selectedProduct.GetComponent<Renderer>().material;
        Color color = material.color;
        color.r = Mathf.Clamp01(color.b * 0.5f);
        material.color = color;
        Debug.Log("New Colour: " + material.color);
    }

}

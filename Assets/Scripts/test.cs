using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Define the glow effect material
    public Material glowMaterial;

    // Define the original materials of the prefab and its children
    private Material[] originalMaterials;

    // Get the original materials of the prefab and its children
    private void Start()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        originalMaterials = new Material[meshRenderers.Length];

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            originalMaterials[i] = meshRenderers[i].material;
        }
    }

    // When the prefab is clicked, apply the glow effect to all of its children
    private void OnMouseDown()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material = glowMaterial;
        }
    }

    // When the prefab is unclicked, restore its original materials
    private void OnMouseUp()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material = originalMaterials[i];
        }
    }
}

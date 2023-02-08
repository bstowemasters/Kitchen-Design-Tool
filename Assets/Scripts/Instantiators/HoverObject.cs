using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverObject : MonoBehaviour
{

    public GameObject unitPrefab;
    public Button button;

    private GameObject hologram;

    private void Start()
    {
        button.onClick.AddListener(CreateHologram);
    }

    private void CreateHologram()
    {
        hologram = Instantiate(unitPrefab);
        hologram.SetActive(true);

    }

    private void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane + 3;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        hologram.transform.position = worldPos;
        

        if (Input.GetMouseButtonDown(0) && hologram != null)
        {
            hologram.transform.position = worldPos;
            hologram = null;

        }

    }

}

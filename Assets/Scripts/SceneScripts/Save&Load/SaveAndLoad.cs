using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoad : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;

    public int cabinetCount;
    public List<GameObject> savedCabinets;

    private void Start()
    {
        saveButton.onClick.AddListener(SaveDesign);
        loadButton.onClick.AddListener(LoadDesign);
    }

    private void SaveDesign()
    {
        var cabinets = GameObject.FindGameObjectsWithTag("Cabinet");

        cabinetCount = cabinets.Length;

        int index = 0;

        if (cabinetCount < 1)
        {
            Debug.Log("No Cabinets To Save");
        }
        else
        {
            savedCabinets = new List<GameObject>();
            foreach (var cabinet in cabinets)
            {

                savedCabinets.Add(cabinet);
                float posX = cabinet.transform.position.x;
                float posY = cabinet.transform.position.y;
                float posZ = cabinet.transform.position.z;

                //float rotY = cabinet.transform.rotation.eulerAngles.y;

                PlayerPrefs.SetFloat("posX" + index, posX);
                PlayerPrefs.SetFloat("posY" + index, posY);
                PlayerPrefs.SetFloat("posZ" + index, posZ);
                //PlayerPrefs.SetFloat("rotationY" + index, rotY);

                index++;
            }
        }


    }
    
    private void LoadDesign()
    {
        if(savedCabinets == null)
        {
            Debug.Log("No Save File Found");
        }else
        {
            deletePrevious();
            GameObject parentObj = GameObject.Find("Cabinets");

            int cabinetCount = savedCabinets.Count;
            for (int i = 0; i < cabinetCount; i++)
            {
                PlayerPrefs.GetFloat("rotY" + i);
                GameObject cabinet = Instantiate(savedCabinets[i]);

                cabinet.transform.position = new Vector3(PlayerPrefs.GetFloat("posX" + i), PlayerPrefs.GetFloat("posY" + i), PlayerPrefs.GetFloat("posZ" + i));
                cabinet.transform.parent = parentObj.transform;
                MonoBehaviour dragScript = cabinet.GetComponent<DragObject>();
                dragScript.enabled = true;
                //cabinet.transform.rotation.eulerAngles = new Vector3(PlayerPrefs.GetFloat("rotX" + i), PlayerPrefs.GetFloat("rotY" + i), PlayerPrefs.GetFloat("rotZ" + i));
            }
        }

        //savedCabinets = null;



    }

    private void deletePrevious()
    {
        GameObject oldDesign = GameObject.Find("Cabinets");


        for(int i = 0; i < oldDesign.transform.childCount; i++)
        {
            GameObject child = oldDesign.transform.GetChild(i).gameObject;
            GameObject.Destroy(child);
        }

        /*
        var designComponents = oldDesign.GetComponentsInChildren<Transform>();
        
        foreach(var component in designComponents)
        {
            GameObject.Destroy(component.gameObject);
        }
        */
        
    }

}

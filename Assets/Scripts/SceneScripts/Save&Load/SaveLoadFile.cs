using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using BensSimpleJSON;
using UnityEditor;
using JetBrains.Annotations;

public class SaveLoadFile : MonoBehaviour
{
    public Button saveToFileButton;
    public Button loadFromFileButton;

    public int cabinetFileCount;
    public bool VR = false;

    public List<GameObject> savedComponents = new List<GameObject>();

    [System.Serializable]
    public class saveData
    {
        public string componentName;
        public int SaveIdx;
        public Vector3 componentPosition;
    }

    private void Start()
    {
        saveToFileButton.onClick.AddListener(saveComponentData);
        loadFromFileButton.onClick.AddListener(loadFileDesign);
        Directory.CreateDirectory(Application.dataPath + "/SaveData/");
    }

    void saveComponentData()
    {
        string saveDataName = Application.dataPath + "/SaveData/" + "SaveData" + ".json";

        // Check file exists and create it if not found, start file with JSON symbol '[' to mark start of object. Overwriting any prev data.
        if (!File.Exists(saveDataName))
        {
            File.WriteAllText(saveDataName, "[\n");
        } else
        {
            File.WriteAllText(saveDataName, "[\n");
        }

        // Create index for number of cabinets to load and 
        List<saveData> componentData = new();
        int idx = 0;

        var cabinets = GameObject.FindGameObjectsWithTag("Cabinet");

        foreach(var cabinet in cabinets)
        {
            // Remove the cabinet "Clone" and iteration numbers from prefab name so they can be instantiated later.
            string cabinetName = cabinet.name;
            cabinetName = cabinetName.Replace("(Clone)", "");
            cabinetName = cabinetName.Replace(" (" + idx + ")", "");

            // Get the source prefab of the gameObject instance (to get path of prefab)

            //GameObject prefab = (GameObject)PrefabUtility.GetPrefabInstanceHandle(cabinet);
            //string prefabPath = AssetDatabase.GetAssetPath(prefab);

            saveData cabinetData = new saveData();
            cabinetData.componentName = cabinetName;
            cabinetData.SaveIdx = idx;
            cabinetData.componentPosition = cabinet.transform.position;

            componentData.Add(cabinetData);



            string jsonData = JsonUtility.ToJson(cabinetData, true);
            File.AppendAllText(saveDataName, jsonData);

            if (idx == cabinets.Length - 1)
            {
                File.AppendAllText(saveDataName, "\n");
            }
            else
            {
                File.AppendAllText(saveDataName, ",\n");
            }
            idx++;

        }

        // End the file with the ] symbol to mark end of json objects.
        File.AppendAllText(saveDataName, "\n]");
        Debug.Log("Saved Cabinet Data To: " + saveDataName);
        
    }

    void loadFileDesign()
    {
        string saveDataName = Application.dataPath + "/SaveData/" + "SaveData" + ".json";
        deletePreviousCabinets();

        if (File.Exists(saveDataName))
        {
            Debug.Log("Found save file");
            
            GameObject parentObj = GameObject.Find("CabinetsVR");


            // Read in the JSON array data from file and convert into readable format.

            string jsonData = File.ReadAllText(saveDataName);   // Gets file data and stores as string

            //var cabinetData = JSONArray.Parse(jsonData);        // Parses data as JSON array
            var cabinetData = SimpleJSON.Parse(jsonData).AsArray;
            int cabinetCount = cabinetData.Count;                 // Stores total cabinets to be loaded in
            Debug.Log("Total = " + cabinetCount);

            foreach (var component in cabinetData)              // Iterates through each element in JSON array and gets cabinet data
            {
                var jsonNode = component.Value as SimpleJSONNode;

                string cabinetName = jsonNode["componentName"];
                int cabinetIdx = jsonNode["SaveIdx"];
                Vector3 cabinetPosition = jsonNode["componentPosition"];

                Debug.Log("This is the cabinet name: " + cabinetName + ".prefab");


                GameObject cabinetToAdd = Resources.Load<GameObject>(cabinetName);
                GameObject addedCabinet = Instantiate(cabinetToAdd);

                addedCabinet.transform.parent = parentObj.transform;

                addedCabinet.transform.position = cabinetPosition;
                
            }
        }
        else
        {
            Debug.Log("Error, Save File Not Found");
        }
    }

    private void deletePreviousCabinets()
    {
        GameObject oldDesign = GameObject.Find("Cabinets");

        if (!VR)
        {
            for (int i = 0; i < oldDesign.transform.childCount; i++)
            {

                GameObject child = oldDesign.transform.GetChild(i).gameObject;
                if (child != null)
                {
                    GameObject.Destroy(child);
                }
            }
        }
        else
        {
            Debug.Log("No Child Elements... Are you using VR?");
        }

    }

    //public void LoadFileDesign()
    //{
    //    if (savedCabinets == null)
    //    {
    //        Debug.Log("No Save File Found");
    //    }
    //    else
    //    {
    //        deletePreviousFile();
    //        GameObject parentObj = GameObject.Find("Cabinets");

    //        int cabinetCount = savedCabinets.Count;
    //        for (int i = 0; i < cabinetCount; i++)
    //        {
    //            PlayerPrefs.GetFloat("rotY" + i);
    //            GameObject cabinet = Instantiate(savedCabinets[i]);

    //            cabinet.transform.position = new Vector3(PlayerPrefs.GetFloat("posX" + i), PlayerPrefs.GetFloat("posY" + i), PlayerPrefs.GetFloat("posZ" + i));
    //            cabinet.transform.parent = parentObj.transform;
    //            MonoBehaviour dragScript = cabinet.GetComponent<DragObject>();
    //            dragScript.enabled = true;
    //        }
    //    }
    //}

    /*
    private void SaveFileDesign()
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

                PlayerPrefs.SetFloat("posX" + index, posX);
                PlayerPrefs.SetFloat("posY" + index, posY);
                PlayerPrefs.SetFloat("posZ" + index, posZ);

                index++;
            }
        }


    }
    */
    /*
    public void LoadFileDesign()
    {
        if (savedCabinets == null)
        {
            Debug.Log("No Save File Found");
        }
        else
        {
            deletePreviousFile();
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
            }
        }
    }

    private void deletePreviousFile()
    {
        GameObject oldDesign = GameObject.Find("Cabinets");


        for (int i = 0; i < oldDesign.transform.childCount; i++)
        {
            GameObject child = oldDesign.transform.GetChild(i).gameObject;
            if (child != null)
            {
                GameObject.Destroy(child);
            }
        }

    }
    */

}

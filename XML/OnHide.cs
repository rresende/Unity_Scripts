using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System.Xml;
using System.IO;
using System;

public class OnHide : MonoBehaviour, IInputClickHandler {
    private List<GameObject> objects = new List<GameObject>();
    private LoadXML xmlClass;
    public bool isHidden;

    public void OnInputClicked(InputClickedEventData eventData)
    {        
        isHidden = !isHidden;
        if (isHidden == true)
            Debug.Log("Hiding...");
        else
            Debug.Log("Repairing...");

        hideObjects(isHidden);
    }

    // Use this for initialization
    void Start () {
        //Get all objects with Hide tag
        isHidden = false;
        GameObject model = GameObject.Find("ISTAR");
        foreach (Transform child in model.transform)
        {
            objects.Add(child.gameObject);
        }

        //Read xml file
        xmlClass = GameObject.Find("Model").GetComponent<LoadXML>();
    }

    void hideObjects(bool hide)
    {
        foreach (GameObject go in objects)
        {
            string id;
            try {
                id = go.name.Substring(go.name.Length - 7, 6);
            }
            catch (ArgumentOutOfRangeException) { continue; }

            Dictionary<string, string> attrList = xmlClass.getListFromId(id);
            if (attrList == null)
                continue;

            string isTransparent = "null";
            if (attrList.TryGetValue("Transparent", out isTransparent))
            {
                if (isTransparent != "null")
                    go.SetActive(!hide);
            }
        }
    }
}

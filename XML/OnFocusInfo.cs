using HoloToolkit.Unity.InputModule;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if NETFX_CORE
using Windows.Storage;
#endif

public class OnFocusInfo : MonoBehaviour, IFocusable
{
    Text uiInfo;
    Text uiInfo2;
    Text uiInfo3;
    GameObject model;

    public void OnFocusEnter()
    {
        //get id
        string id;
        try
        {
            id = name.Substring(name.Length - 7, 6);
        } catch (ArgumentOutOfRangeException)
        {
            return;
        }        

        //get info from ID
        Dictionary<string, string> attrList = model.GetComponent<LoadXML>().getListFromId(id);
        string value = "null";
        if (attrList.TryGetValue("Category",out value) || value != null)
            uiInfo.text = "Categoria: " + value + "; ";
        if (attrList.TryGetValue("Family", out value) || value != null)
            uiInfo2.text = "Família: " + value + "; ";
        if (attrList.TryGetValue("Mark", out value) || value != null)
            uiInfo3.text = value + "; ";

    }

    public void OnFocusExit()
    {
        //clear text
        uiInfo.text = "";
        uiInfo2.text = "";
        uiInfo3.text = "";
    }

    // Use this for initialization
    void Start()
    {

        //load everything
        model = GameObject.Find("Model");
        uiInfo = model.GetComponent<LoadXML>().uiInfo;
        uiInfo2 = model.GetComponent<LoadXML>().uiInfo2;
        uiInfo3 = model.GetComponent<LoadXML>().uiInfo3;

        //adds OnFocusInfo script to every object under the ISTAR model
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<OnFocusInfo>();
            child.gameObject.AddComponent<BoxCollider>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

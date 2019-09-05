using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;
#if NETFX_CORE
using Windows.Storage;
#endif

public class LoadXML : MonoBehaviour {

    public Dictionary<string, Dictionary<string, string>> xmlList;
    public Text uiInfo;
    public Text uiInfo2;
    public Text uiInfo3;
    Vector3 originalPos;

    // Use this for initialization
    void Start () {
        var path = Application.dataPath + "\\xml\\";

        if (path.Contains("C:")) //to check if we are running inside HoloLens
        {

#if NETFX_CORE
            path = KnownFolders.CameraRoll.Path + "\\";
            //path = ApplicationData.Current.LocalFolder.Path + "\\";
#endif
         }

        //Get canvas (text) object
        GameObject goInfo = GameObject.Find("Text");
        if (goInfo != null)
        {
            //If we found the object , get the Canvas component from it.
            uiInfo = goInfo.GetComponent<Text>();
        }
        GameObject goInfo2 = GameObject.Find("Text2");
        if (goInfo2 != null)
        {
            //If we found the object , get the Canvas component from it.
            uiInfo2 = goInfo2.GetComponent<Text>();
        }
        GameObject goInfo3 = GameObject.Find("Text3");
        if (goInfo3 != null)
        {
            //If we found the object , get the Canvas component from it.
            uiInfo3 = goInfo3.GetComponent<Text>();
        }

        //Read xml file
        XDocument xmldoc = XDocument.Load(path + "Sala_ISTAR.xml");
        xmlList = new Dictionary<string, Dictionary<string, string>>();

        foreach (XElement root in xmldoc.Descendants())
        {
            foreach (XElement elements in root.Descendants())
            {
                Dictionary<string, string> attribute = new Dictionary<string, string>();
                var id = "";
                foreach (XElement element in elements.Descendants())
                {
                    if (element.Name.ToString() == "id")
                        id = element.Value;
                    else
                        attribute.Add(element.Name.ToString(), element.Value);
                }
                if (id != "")
                    xmlList.Add(id, attribute);
            }
        }
    }

    public Dictionary<string, string> getListFromId(string id)
    {
        Dictionary<string, string> attributes;
        xmlList.TryGetValue(id, out attributes);
        return attributes;       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ChangeMatOnFocus : MonoBehaviour, IFocusable
{
    Material[] matList;
    Material[] oldMatList;
    void IFocusable.OnFocusEnter()
    {
        foreach(Material mat in matList)
        {
            if (mat.GetFloat("_Mode") != 3)
            {
                //Set rendering mode as Transparent
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                mat.SetInt("_ZWrite", 0);
                mat.DisableKeyword("_ALPHATEST_ON");
                mat.DisableKeyword("_ALPHABLEND_ON");
                mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                mat.renderQueue = 3000;
            }            
        }
    }

    void IFocusable.OnFocusExit()
    {
        for (int i = 0; i < matList.Length; i++)
        {

        }
    }

    // Use this for initialization
    void Start () {
        matList = gameObject.GetComponents<Material>();
        oldMatList = matList;
        foreach (Transform child in transform)
        {
            child.gameObject.AddComponent<ChangeMatOnFocus>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

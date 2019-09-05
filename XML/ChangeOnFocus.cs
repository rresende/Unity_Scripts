using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ChangeOnFocus : MonoBehaviour, IFocusable {
    Color newColor = Color.gray;
    Color oldColor;
    Vector3 oldScale;

    void IFocusable.OnFocusEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
        gameObject.transform.localScale = oldScale * 1.2f;
    }

    void IFocusable.OnFocusExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = oldColor;
        gameObject.transform.localScale = oldScale;
    }

    // Use this for initialization
    void Start () {
        oldColor = gameObject.GetComponent<SpriteRenderer>().color;
        oldScale = gameObject.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

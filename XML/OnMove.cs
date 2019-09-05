using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.EventSystems;
using HoloToolkit.Unity.SpatialMapping;

public class OnMove : MonoBehaviour, IInputClickHandler {
    private TapToPlace tapScript;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Moving...");
        tapScript.OnInputClicked(eventData);
    }

    // Use this for initialization
    void Start () {
        tapScript = (TapToPlace) (FindObjectOfType(typeof(TapToPlace)));        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

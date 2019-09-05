using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class OnClose : MonoBehaviour, IInputClickHandler {


    public void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

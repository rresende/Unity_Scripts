using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class OnZoom : MonoBehaviour, IInputClickHandler, IManipulationHandler {

    public bool isZoomActive;
    Color newColor = Color.green;
    Sprite plusZoom;
    Sprite minusZoom;
    Sprite oldSprite;
    Color oldColor;
    private Vector3 newScale;
    GameObject goStatic; 

    void IInputClickHandler.OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("Zooming...");
    }

    void IManipulationHandler.OnManipulationCanceled(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
        gameObject.GetComponent<SpriteRenderer>().color = oldColor;
        gameObject.GetComponent<SpriteRenderer>().sprite = oldSprite;
    }

    void IManipulationHandler.OnManipulationCompleted(ManipulationEventData eventData)
    {
        InputManager.Instance.PopModalInputHandler();
        gameObject.GetComponent<SpriteRenderer>().color = oldColor;
        gameObject.GetComponent<SpriteRenderer>().sprite = oldSprite;
    }

    void IManipulationHandler.OnManipulationStarted(ManipulationEventData eventData)
    {
        gameObject.GetComponent<SpriteRenderer>().color = newColor;
        InputManager.Instance.PushModalInputHandler(gameObject); //this makes sure we get the manipulation data even if the gaze is not on our gameobject
    }

    void IManipulationHandler.OnManipulationUpdated(ManipulationEventData eventData)
    {
        newScale = goStatic.transform.localScale; //old size

        newScale.x = newScale.x + (eventData.CumulativeDelta.x * 0.05f);
        newScale.y = newScale.y + (eventData.CumulativeDelta.x * 0.05f);
        newScale.z = newScale.z + (eventData.CumulativeDelta.x * 0.05f);

        goStatic.transform.localScale = newScale;

        if (eventData.CumulativeDelta.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plusZoom;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = minusZoom;
        }
    }

    void Start()
    {
        goStatic = GameObject.Find("ISTAR");
        oldColor = gameObject.GetComponent<SpriteRenderer>().color;
        oldSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        plusZoom = Resources.Load<Sprite>("28-01");
        minusZoom = Resources.Load<Sprite>("27-01");
    }
    void Update()
    {

    }
}

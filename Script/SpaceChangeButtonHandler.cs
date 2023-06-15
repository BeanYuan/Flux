using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SpaceChangeButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        SceneController.instance.SpaceChange();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}

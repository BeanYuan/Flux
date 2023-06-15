using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class RewindButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        TimeManager.isRewinding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        TimeManager.isRewinding = false;
    }
}

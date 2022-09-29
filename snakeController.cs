using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class snakeController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private UnityEvent pressed;

    [SerializeField]
    private UnityEvent unpressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        unpressed.Invoke();
    }
}

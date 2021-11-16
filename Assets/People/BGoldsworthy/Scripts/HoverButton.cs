using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hover Start");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Hover Stop");
    }
}

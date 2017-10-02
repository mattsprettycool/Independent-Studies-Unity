using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slotSelector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SendYee();
        Debug.Log(eventData);
        throw new System.NotImplementedException();
    }

    public void SendYee()
    {
        Debug.Log("yee");
    }
}

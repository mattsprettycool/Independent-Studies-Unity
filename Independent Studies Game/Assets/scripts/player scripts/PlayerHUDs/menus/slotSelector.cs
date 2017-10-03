using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slotSelector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.timeScale == 0f)
        {
            Camera.main.gameObject.GetComponent<ItemSwapper>().AddSlot(gameObject.tag);
        }
    }
}

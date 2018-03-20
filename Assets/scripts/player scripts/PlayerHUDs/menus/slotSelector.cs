﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//by Matt Braden
public class slotSelector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.timeScale == 0f&&Input.GetKeyUp(KeyCode.Mouse0)&&!GameObject.FindGameObjectWithTag("ItemBarHolder").GetComponent<ItemBar>().IsOnCooldown())
        {
            GameObject.FindGameObjectWithTag("ItemBarHolder").GetComponent<ItemSwapper>().AddSlot(gameObject.tag);
        }
    }
}

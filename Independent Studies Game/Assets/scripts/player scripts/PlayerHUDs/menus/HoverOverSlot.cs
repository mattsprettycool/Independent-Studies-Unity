using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverOverSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public GameObject selector;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Time.timeScale == 0f)
        {
            selector.GetComponent<Image>().enabled = true;
            selector.transform.position = gameObject.transform.position;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Time.timeScale == 0f)
        {
            selector.GetComponent<Image>().enabled = false;
        }
    }

}

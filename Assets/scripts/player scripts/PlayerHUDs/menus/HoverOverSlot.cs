using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//by Matt Braden
public class HoverOverSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    public GameObject selector;
    bool isHovered = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)&&isHovered)
        {
            if (gameObject.tag.Contains("i"))
            {
                GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>().RemoveItemAtSpot(gameObject.tag);
            }
            else if (gameObject.tag.Contains("h"))
            {
                Camera.main.gameObject.GetComponent<ItemBar>().RemoveItemAtSpot(gameObject.tag);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Time.timeScale == 0f)
        {
            selector.GetComponent<Image>().enabled = true;
            selector.transform.position = gameObject.transform.position;
            isHovered = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Time.timeScale == 0f)
        {
            selector.GetComponent<Image>().enabled = false;
            isHovered = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
//by Matt Braden
public class InventoryScreen : MonoBehaviour
{
    bool toggle;
    //this string outputs every error in the try catch statements
    String errors;
    [SerializeField]
    public Sprite nullImage;
    //the array of items in the inventory
    [SerializeField]
    public GameObject[] itemArray = new GameObject[30];
    ItemBar iBar;
    // Use this for initialization
    void Start()
    {
        toggle = true;
        //this initially hides the inventory screen
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        //this makes every single icon clear
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("slot")) obj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        errors = "";
        iBar = Camera.main.gameObject.GetComponent<ItemBar>();
    }

    // Update is called once per frame
    void Update()
    {
        //if you press tab and toggle is true, it pauses the game and opens the inventory
        if (Input.GetKeyDown(KeyCode.Tab) && toggle)
        {
            Time.timeScale = 0f;
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            toggle = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !toggle)
        {
            Time.timeScale = 1f;
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            toggle = true;
        }
        if (!toggle)
        {
            showIcons();
        }
        else
            hideIcons();
        if (iBar.commWithIscreen && !this.IsFull())
        {
            AddItem(iBar.pM.recentPickUp);
            iBar.commWithIscreen = false;
        }
    }
    //shows all the icons in the ui
    public void showIcons()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("slot")) obj.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        for (int i = 0; i < 30; i++)
            try
            {
                GameObject.FindGameObjectWithTag("i" + i).GetComponent<Image>().overrideSprite = itemArray[i].GetComponent<attackLibrary>().icon;
            }
            catch (Exception e)
            {
                errors += e;
            }
    }
    //hides all the icons in the ui
    public void hideIcons()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("slot")) obj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        for (int i = 0; i < 30; i++)
            try
            {
                GameObject.FindGameObjectWithTag("i" + i).GetComponent<Image>().overrideSprite = nullImage;
            }
            catch (Exception e)
            {
                errors += e;
            }
    }
    //returns true if the inventory is full
    public bool IsFull()
    {
        int ammNotNull = 0;
        for (int i = 0; i < 30; i++) if (itemArray[i] != null) ammNotNull++;
        if (ammNotNull <= 30) return false;
        return true;
    }
    //adds the item at the first empty slot
    void AddItem(GameObject itemToAdd)
    {
        for (int i = 0; i < 30; i++)
        {
            if (itemArray[i] == null)
            {
                itemArray[i] = itemToAdd;
                i = 30;
            }
        }
    }
    //Adds the item at the specified slot
    public void AddItemAtSpot(GameObject itemToAdd, string spotTag)
    {
        for (int i = 0; i < 30; i++)
        {
            if (spotTag.Equals("i" + i))
            {
                itemArray[i] = itemToAdd;
                showIcons();
                i = 30;
            }
        }
    }
    //Removes the item at the specified slot
    public void RemoveItemAtSpot(string spotTag)
    {
        for (int i = 0; i < 30; i++)
        {
            if (spotTag.Equals("i" + i))
            {
                itemArray[i] = null;
                hideIcons();
                showIcons();
                i = 30;
            }
        }
    }
    //gets the item at the specified slot
    public GameObject GetItemAtSpot(string spotTag)
    {
        for (int i = 0; i < 30; i++)
        {
            if (spotTag.Equals("i" + i))
            {
                return itemArray[i];
            }
        }
        return null;
    }
}

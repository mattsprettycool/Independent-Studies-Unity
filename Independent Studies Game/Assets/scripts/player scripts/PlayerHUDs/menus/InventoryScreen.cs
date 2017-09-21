﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryScreen : MonoBehaviour {
    bool toggle;
    //this string outputs every error in the try catch statements
    String errors;
    [SerializeField]
    public Sprite nullImage;
    //the array of items in the inventory
    [SerializeField]
    public GameObject[] itemArray = new GameObject[30];
    //number of non-null objects in the array
    int objectsInArray;
    // Use this for initialization
    void Start () {
        toggle = true;
        //this initially hides the inventory screen
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        //this makes every single icon clear
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("slot")) obj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        errors = "";
        objectsInArray = 0;
    }
	
	// Update is called once per frame
	void Update () {
        objectsInArray = 0;
        for (int i = 0; i < 30; i++) if (itemArray[i] != null) objectsInArray++;
        if (Input.GetKeyDown(KeyCode.Tab)&&toggle)
        {
            Time.timeScale = 0f;
            gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            toggle = false;
        }else if (Input.GetKeyDown(KeyCode.Tab) && !toggle)
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
    }
    void showIcons()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("slot")) obj.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        for (int i = 0; i < 30; i++)
            try
            {
                GameObject.FindGameObjectWithTag("i"+i).GetComponent<Image>().overrideSprite = itemArray[i].GetComponent<attackLibrary>().icon;
            }
            catch(Exception e)
            {
                errors += e;
            }
    }
    void hideIcons()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("slot")) obj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        for (int i = 0; i < 30; i++)
            try
            {
                GameObject.FindGameObjectWithTag("i"+i).GetComponent<Image>().overrideSprite = nullImage;
            }
            catch (Exception e)
            {
                errors += e;
            }
    }
}
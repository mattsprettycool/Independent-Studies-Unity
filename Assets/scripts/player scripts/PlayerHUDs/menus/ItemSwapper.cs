﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Matt Braden
public class ItemSwapper : MonoBehaviour {
    [SerializeField]
    public string spot1, spot2;
    ItemBar iBar;
    InventoryScreen iScreen;
    bool stage;
    bool swap;
    // Use this for initialization
    void Start () {
        iBar = GameObject.FindGameObjectWithTag("ItemBarHolder").GetComponent<ItemBar>();
        iScreen = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>();
        swap = false;
        stage = false;
    }
	
	// Update is called once per frame
	void Update () {
        //DEBUG CODE
        GameObject g1 = null, g2 = null;
        if (swap&& !GameObject.FindGameObjectWithTag("ItemBarHolder").GetComponent<ItemBar>().IsOnCooldown())
        {
            if (spot1.Contains("h")) g1 = iBar.GetItemAtSpot(spot1);
            if (spot1.Contains("i")) g1 = iScreen.GetItemAtSpot(spot1);
            if (spot2.Contains("h")) g2 = iBar.GetItemAtSpot(spot2);
            if (spot2.Contains("i")) g2 = iScreen.GetItemAtSpot(spot2);
            if (spot1.Contains("h"))
            {
                iBar.AddItemAtSpot(g2, spot1);
                iBar.updateAttacks();
            }else if (spot1.Contains("i"))
            {
                iScreen.AddItemAtSpot(g2, spot1);
                iScreen.hideIcons();
                iScreen.showIcons();
            }

            if (spot2.Contains("h"))
            {
                iBar.AddItemAtSpot(g1, spot2);
                iBar.updateAttacks();
            }
            else if (spot2.Contains("i"))
            {
                iScreen.AddItemAtSpot(g1, spot2);
                iScreen.hideIcons();
                iScreen.showIcons();
            }
            swap = false;
            GameObject.FindGameObjectWithTag("c1").GetComponent<Image>().enabled = false;
            GameObject.FindGameObjectWithTag("c2").GetComponent<Image>().enabled = false;
            spot1 = "";
            spot2 = "";
        }
	}
    /* Author - Matt Braden
     * Adds the specified slot to the list of two items to swap
     * sName - a string that has a format of "h#" or i#" where # is a number and h specifies "hotbar" and i specifies "item slot", h has a bound from 0-8 and i has a bound from 0-29
     */
    public void AddSlot(string sName)
    {
        if(!stage)
        {
            spot1 = sName;
            stage = true;
            GameObject.FindGameObjectWithTag("c1").transform.position = GameObject.FindGameObjectWithTag(sName).transform.position;
            GameObject.FindGameObjectWithTag("c1").GetComponent<Image>().enabled = true;
        }
        else if(stage)
        {
            spot2 = sName;
            swap = true;
            stage = false;
            GameObject.FindGameObjectWithTag("c2").transform.position = GameObject.FindGameObjectWithTag(sName).transform.position;
            GameObject.FindGameObjectWithTag("c2").GetComponent<Image>().enabled = true;
        }
        else
        {
            stage = false;
        }
    }
}

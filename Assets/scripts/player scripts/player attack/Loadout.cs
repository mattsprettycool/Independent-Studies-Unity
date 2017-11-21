using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour {
    [SerializeField]
    public string loadoutName;
    [SerializeField]
    public GameObject[] hotbar = new GameObject[9];
    [SerializeField]
    public GameObject[] inventory = new GameObject[30];
    public string GetName()
    {
        return loadoutName;
    }
    public GameObject[] GetHotbar()
    {
        return hotbar;
    }
    public GameObject[] GetInventory()
    {
        return inventory;
    }
    public void SetHotbar(Loadout currentHotbar)
    {
        hotbar = currentHotbar.GetHotbar();
    }
    public void SetHotbar(GameObject[] currentHotbar)
    {
        hotbar = currentHotbar;
    }
    public void SetInventory(Loadout currentInventory)
    {
        inventory = currentInventory.GetInventory();
    }
    public void SetInventory(GameObject[] currentInventory)
    {
        inventory = currentInventory;
    }
}

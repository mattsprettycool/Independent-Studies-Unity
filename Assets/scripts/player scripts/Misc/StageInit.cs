using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInit : MonoBehaviour {
    [SerializeField]
    GameObject hotbar, inventory, loadoutPrefab;
    ItemBar myHotbar;
    InventoryScreen myInventory;
    Loadout myLoadout;
	// Use this for initialization
	void Start () {
        myHotbar = hotbar.GetComponent<ItemBar>();
        myInventory = inventory.GetComponent<InventoryScreen>();
        myLoadout = loadoutPrefab.GetComponent<Loadout>();

        int i = 0;
        foreach(GameObject obj in myLoadout.GetHotbar())
        {
            myHotbar.AddItemAtSpot(obj, "h" + i);
            i++;
        }

        i = 0;
        foreach (GameObject obj in myLoadout.GetInventory())
        {
            myInventory.AddItemAtSpot(obj, "i" + i);
            i++;
        }
    }
    private void Update()
    {
        myLoadout.SetHotbar(myHotbar.GetHotbarArray());
        myLoadout.SetInventory(myInventory.GetInventoryArray());
    }
}

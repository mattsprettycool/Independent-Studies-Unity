using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwapper : MonoBehaviour {
    [SerializeField]
    public string spot1, spot2;
    ItemBar iBar;
    InventoryScreen iScreen;
    bool stage;
    bool swap;
    // Use this for initialization
    void Start () {
        iBar = Camera.main.gameObject.GetComponent<ItemBar>();
        iScreen = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>();
        swap = false;
        stage = false;
    }
	
	// Update is called once per frame
	void Update () {
        //DEBUG CODE
        GameObject g1 = null, g2 = null;
        if (swap)
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
        }
	}
    public void AddSlot(string sName)
    {
        if(!stage)
        {
            spot1 = sName;
            stage = true;
        }else if(stage)
        {
            spot2 = sName;
            swap = true;
            stage = false;
        }
        else
        {
            stage = false;
        }
    }
}

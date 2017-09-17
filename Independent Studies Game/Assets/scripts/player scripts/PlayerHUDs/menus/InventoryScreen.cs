using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryScreen : MonoBehaviour {
    bool toggle;
    String errors;
    [SerializeField]
    public Sprite nullImage;
    [SerializeField]
    public GameObject item0, item1, item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item13, item14, item15, item16, item17, item18, item19, item20, item21, item22, item23, item24, item25, item26, item27, item28, item29;
    GameObject[] itemArray = new GameObject[30];
    // Use this for initialization
    void Start () {
        toggle = true;
        gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("slot")) obj.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        errors = "";
    }
	
	// Update is called once per frame
	void Update () {
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
        updateArray();
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
    void updateArray()
    {
        itemArray[0] = item0;
        itemArray[1] = item1;
        itemArray[2] = item2;
        itemArray[3] = item3;
        itemArray[4] = item4;
        itemArray[5] = item5;
        itemArray[6] = item6;
        itemArray[7] = item7;
        itemArray[8] = item8;
        itemArray[9] = item9;
        itemArray[10] = item10;
        itemArray[11] = item11;
        itemArray[12] = item12;
        itemArray[13] = item13;
        itemArray[14] = item14;
        itemArray[15] = item15;
        itemArray[16] = item16;
        itemArray[17] = item17;
        itemArray[18] = item18;
        itemArray[19] = item19;
        itemArray[20] = item20;
        itemArray[21] = item21;
        itemArray[22] = item22;
        itemArray[23] = item23;
        itemArray[24] = item24;
        itemArray[25] = item25;
        itemArray[26] = item26;
        itemArray[27] = item27;
        itemArray[28] = item28;
        itemArray[29] = item29;
    }
}

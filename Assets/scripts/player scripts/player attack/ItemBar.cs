﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

//by Matt Braden
/*
 * In order to make an interchangable bar of weapons and spells, this file will allow for the swapping out of
 * spells and weapons. Each "spell" and "weapon" is going to be a prefab of an empty with an unique script in it
 * that holds the program for the attack. If you need help understanding, just ask. At a future point, I would like
 * there to be a skill bar on the ui, but that is currently not the important part.
 */
public class ItemBar : MonoBehaviour {
    //all these attacks are changable both in game and in inspector
    public GameObject attack0, attack1, attack2, attack3, attack4, attack5, attack6, attack7, attack8;
    //the attack library of each item
    attackLibrary lib0, lib1, lib2, lib3, lib4, lib5, lib6, lib7, lib8;
    //the hotbar slot you are selecting
    [SerializeField]
    public int pointer;
    int currentPoint;
    int virtualPointer = 0;
	float switchTimer;
	public bool justSwitched;
    bool justStarted;
    String debugger;
    public PlayerMovement pM;
    bool updateNeeded;
    public bool commWithIscreen;
    CameraMovement cm;
    int pleaseDontLag = 5;
    float[,] savedValuesArr;
    float[] cooldownArr;
	// Use this for initialization
	void Start () {
        updateAttacks();
        pointer = 0;
        currentPoint = 0;
        justStarted = true;
        debugger = "";
        updateNeeded = false;
        //gets the playermovement script from the player
        pM = GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(PlayerMovement)) as PlayerMovement;
        commWithIscreen = false;
        cm = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraMovement>();
        savedValuesArr = new float[8, 10];
        cooldownArr = new float[8];
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        UpdatePointer();
        if (pleaseDontLag <= 0)
        {
            UpdateCooldownIcons();
            changeAttacks();
            //int pointerTemp = pointer;
            updateAttacks();
            setAttacks();
            setHotbarSelect();
            //if(pointer != pointerTemp){ }
            //tries to add an item to the hotbar
            if (pM.doCommunicate && !this.IsFull())
            {
                this.AddItem(pM.recentPickUp);
                pM.setCommToFalse();
                updateNeeded = true;
            }
            else if (pM.doCommunicate)
            {
                commWithIscreen = true;
                pM.setCommToFalse();
                updateNeeded = true;
            }
            if (justSwitched)
            {
                switchTimer += Time.deltaTime;
                if (switchTimer > 5)
                {
                    justSwitched = false;
                    switchTimer = 0;
                }
            }
            pleaseDontLag = 5;
        }
        else
            pleaseDontLag--;
    }
    /*Author - Matt Braden
     * sets the hotbar you are selecting based on the pointer value
     */
    void setHotbarSelect()
    {
        GameObject hotSel = GameObject.FindGameObjectWithTag("slotManager");
        if (pointer == 0) hotSel.transform.position = GameObject.FindGameObjectWithTag("h0").transform.position;
        if (pointer == 1) hotSel.transform.position = GameObject.FindGameObjectWithTag("h1").transform.position;
        if (pointer == 2) hotSel.transform.position = GameObject.FindGameObjectWithTag("h2").transform.position;
        if (pointer == 3) hotSel.transform.position = GameObject.FindGameObjectWithTag("h3").transform.position;
        if (pointer == 4) hotSel.transform.position = GameObject.FindGameObjectWithTag("h4").transform.position;
        if (pointer == 5) hotSel.transform.position = GameObject.FindGameObjectWithTag("h5").transform.position;
        if (pointer == 6) hotSel.transform.position = GameObject.FindGameObjectWithTag("h6").transform.position;
        if (pointer == 7) hotSel.transform.position = GameObject.FindGameObjectWithTag("h7").transform.position;
        if (pointer == 8) hotSel.transform.position = GameObject.FindGameObjectWithTag("h8").transform.position;
    }
    /* Author - Matt Braden
     * updates the attacks to account for any changes
     */ 
    public void updateAttacks()
    {
        //IMPORTANT!!!! in order to use try/catch, you need to first import it by typing "using System" at the top
        try
        {
            lib0 = attack0.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h0").GetComponent<Image>().overrideSprite = lib0.icon;
            
        }
        catch (Exception e)
        {
            //if an exception is made, it skips the code and adds to the error string
            debugger += "\n"+e;
            GameObject.FindGameObjectWithTag("h0").GetComponent<Image>().overrideSprite = null;
        }
        try
        {
            lib1 = attack1.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h1").GetComponent<Image>().overrideSprite = lib1.icon;
            
        }
        catch (Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h1").GetComponent<Image>().overrideSprite = null;
        }
        try
        {
            lib2 = attack2.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h2").GetComponent<Image>().overrideSprite = lib2.icon;
            
        }
        catch (Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h2").GetComponent<Image>().overrideSprite = null;
        }
        try {
            lib3 = attack3.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h3").GetComponent<Image>().overrideSprite = lib3.icon;
            
        }
        catch(Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h3").GetComponent<Image>().overrideSprite = null;
        }
        try
        {
            lib4 = attack4.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h4").GetComponent<Image>().overrideSprite = lib4.icon;
            
        }
        catch (Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h4").GetComponent<Image>().overrideSprite = null;
        }
        try
        {
            lib5 = attack5.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h5").GetComponent<Image>().overrideSprite = lib5.icon;
            
        }
        catch (Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h5").GetComponent<Image>().overrideSprite = null;
        }
        try
        {
            lib6 = attack6.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h6").GetComponent<Image>().overrideSprite = lib6.icon;
            
        }
        catch (Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h6").GetComponent<Image>().overrideSprite = null;
        }
        try
        {
            lib7 = attack7.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h7").GetComponent<Image>().overrideSprite = lib7.icon;
            
        }
        catch (Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h7").GetComponent<Image>().overrideSprite = null;
        }
        try
        {
            lib8 = attack8.GetComponent(typeof(attackLibrary)) as attackLibrary;
            GameObject.FindGameObjectWithTag("h8").GetComponent<Image>().overrideSprite = lib8.icon;
            
        }
        catch (Exception e)
        {
            debugger += "\n" + e;
            GameObject.FindGameObjectWithTag("h8").GetComponent<Image>().overrideSprite = null;
        }
    }
    /* Author - Matt Braden
     * changes the pointer val based on pressing numbers and scrolling
     */ 
    void changeAttacks()
    {
        if (pointer != virtualPointer)
        {
            UpdatePrevItem(pointer);
            pointer = virtualPointer;
            UpdateCurrentItem(pointer);
        }
    }
    void UpdatePointer()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            virtualPointer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            virtualPointer = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            virtualPointer = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            virtualPointer = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            virtualPointer = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            virtualPointer = 5;
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            virtualPointer = 6;
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            virtualPointer = 7;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            virtualPointer = 8;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (pointer < 8)
            {
                virtualPointer++;
            }
            else
            {
                virtualPointer = 0;
            }

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (pointer > 0)
            {
                virtualPointer--;
            }
            else
            {
                virtualPointer = 8;
            }

        }
    }
    /* Author - Matt Braden
     * creates new and destroys previous attacks
     */
    void setAttacks()
    {
        GameObject[] attacks = GameObject.FindGameObjectsWithTag("attacks");
        if (justStarted)
        {
            //destroys all objects with the attack tag, which is found above ^
            foreach (GameObject obj in attacks) Destroy(obj);
            try{
                //creates a variable of the prefab, and then uses attacklibrary variables in them to set the positions
                var attackInst = Instantiate(attack0);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib0.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib0.rotX, lib0.rotY, lib0.rotZ);
                cm.SetIsInFirstPerson(!lib0.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 0;
            justStarted = false;
        }
        if((pointer == 0 && currentPoint != 0 && !justStarted)|| (currentPoint == 0 && updateNeeded))
        {
            justSwitched = true;
            foreach (GameObject obj in attacks) Destroy(obj);
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack0);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib0.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib0.rotX, lib0.rotY, lib0.rotZ);
                cm.SetIsInFirstPerson(!lib0.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 0;
        }
        if ((pointer == 1 && currentPoint != 1 && !justStarted)|| (currentPoint == 1 && updateNeeded))
        {
            justSwitched = true;
            foreach (GameObject obj in attacks) Destroy(obj);
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack1);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib1.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib1.rotX, lib1.rotY, lib1.rotZ);
                cm.SetIsInFirstPerson(!lib1.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 1;
        }
        if ((pointer == 2 && currentPoint != 2 && !justStarted)|| (currentPoint == 2 && updateNeeded))
        {
            justSwitched = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            foreach (GameObject obj in attacks) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack2);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib2.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib2.rotX, lib2.rotY, lib2.rotZ);
                cm.SetIsInFirstPerson(!lib2.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 2;
        }
        if ((pointer == 3 && currentPoint != 3 && !justStarted)|| (currentPoint == 3 && updateNeeded))
        {
            justSwitched = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            foreach (GameObject obj in attacks) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack3);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib3.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib3.rotX, lib3.rotY, lib3.rotZ);
                cm.SetIsInFirstPerson(!lib3.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 3;
        }
        if ((pointer == 4 && currentPoint != 4 && !justStarted)|| (currentPoint == 4 && updateNeeded))
        {
            justSwitched = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            foreach (GameObject obj in attacks) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack4);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib4.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib4.rotX, lib4.rotY, lib4.rotZ);
                cm.SetIsInFirstPerson(!lib4.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 4;
        }
        if ((pointer == 5 && currentPoint != 5 && !justStarted)|| (currentPoint == 5 && updateNeeded))
        {
            justSwitched = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            foreach (GameObject obj in attacks) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack5);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib5.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib5.rotX, lib5.rotY, lib5.rotZ);
                cm.SetIsInFirstPerson(!lib5.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 5;
        }
        if ((pointer == 6 && currentPoint != 6 && !justStarted)|| (currentPoint == 6 && updateNeeded))
        {
            justSwitched = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            foreach (GameObject obj in attacks) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack6);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib6.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib6.rotX, lib6.rotY, lib6.rotZ);
                cm.SetIsInFirstPerson(!lib6.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 6;
        }
        if ((pointer == 7 && currentPoint != 7 && !justStarted)|| (currentPoint == 7 && updateNeeded))
        {
            justSwitched = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            foreach (GameObject obj in attacks) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack7);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib7.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib7.rotX, lib7.rotY, lib7.rotZ);
                cm.SetIsInFirstPerson(!lib7.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 7;
        }
        if ((pointer == 8 && currentPoint != 8 && !justStarted)||(currentPoint == 8 && updateNeeded))
        {
            justSwitched = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("attackPreview");
            foreach (GameObject obj in objs) Destroy(obj);
            foreach (GameObject obj in attacks) Destroy(obj);
            try
            {
                var attackInst = Instantiate(attack8);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib8.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib8.rotX, lib8.rotY, lib8.rotZ);
                cm.SetIsInFirstPerson(!lib8.IsInThirdPerson);
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 8;
        }
    }
    /* Author - Matt Braden
     * tests if the hotbar is full
     */
    public bool IsFull()
    {
        return (attack0 != null && attack1 != null && attack2 != null && attack3 != null && attack4 != null && attack5 != null && attack6 != null && attack7 != null && attack8 != null);
    }
    /* Author - Matt Braden
     * adds an item to the first empty slot in the hotbar
     * prefabToCopy - GameObject that will be added to a slot
     * return - true if full, false if otherwise
     */
    void AddItem(GameObject prefabToCopy)
    {
        if (attack0 == null)
        {
            attack0 = prefabToCopy;
        }else if (attack1 == null)
        {
            attack1 = prefabToCopy;
        }
        else if (attack2 == null)
        {
            attack2 = prefabToCopy;
        }
        else if (attack3 == null)
        {
            attack3 = prefabToCopy;
        }
        else if (attack4 == null)
        {
            attack4 = prefabToCopy;
        }
        else if (attack5 == null)
        {
            attack5 = prefabToCopy;
        }
        else if (attack6 == null)
        {
            attack6 = prefabToCopy;
        }
        else if (attack7 == null)
        {
            attack7 = prefabToCopy;
        }
        else if (attack8 == null)
        {
            attack8 = prefabToCopy;
        }
    }
    /* Author - Matt Braden
     * Adds an item to the specified slot
     * GameObject itemToAdd - item that gets added to the specified slot
     * string spotTag - a string that has a format of "h#" where # is a number and h specifies "hotbar" , h has a bound from 0-8
     */
    public void AddItemAtSpot(GameObject itemToAdd, string spotTag)
    {
        if (spotTag.Equals("h0"))
        {
            attack0 = itemToAdd;
        }else if (spotTag.Equals("h1"))
        {
            attack1 = itemToAdd;
        }
        else if (spotTag.Equals("h2"))
        {
            attack2 = itemToAdd;
        }
        else if (spotTag.Equals("h3"))
        {
            attack3 = itemToAdd;
        }
        else if (spotTag.Equals("h4"))
        {
            attack4 = itemToAdd;
        }
        else if (spotTag.Equals("h5"))
        {
            attack5 = itemToAdd;
        }
        else if (spotTag.Equals("h6"))
        {
            attack6 = itemToAdd;
        }
        else if (spotTag.Equals("h7"))
        {
            attack7 = itemToAdd;
        }
        else if (spotTag.Equals("h8"))
        {
            attack8 = itemToAdd;
        }
        updateAttacks();
        setAttacks();
    }
    /* Author - Matt Braden
     * removes an item at the specified slot
     * 
     */
    public void RemoveItemAtSpot(string spotTag)
    {
        if (spotTag.Equals("h0"))
        {
            attack0 = null;
        }
        else if (spotTag.Equals("h1"))
        {
            attack1 = null;
        }
        else if (spotTag.Equals("h2"))
        {
            attack2 = null;
        }
        else if (spotTag.Equals("h3"))
        {
            attack3 = null;
        }
        else if (spotTag.Equals("h4"))
        {
            attack4 = null;
        }
        else if (spotTag.Equals("h5"))
        {
            attack5 = null;
        }
        else if (spotTag.Equals("h6"))
        {
            attack6 = null;
        }
        else if (spotTag.Equals("h7"))
        {
            attack7 = null;
        }
        else if (spotTag.Equals("h8"))
        {
            attack8 = null;
        }
        updateAttacks();
        setAttacks();
    }
    //Gets the item at the specified slot
    public GameObject GetItemAtSpot(string spotTag)
    {
        if (spotTag.Equals("h0"))
        {
            return attack0;
        }
        else if (spotTag.Equals("h1"))
        {
            return attack1;
        }
        else if (spotTag.Equals("h2"))
        {
            return attack2;
        }
        else if (spotTag.Equals("h3"))
        {
            return attack3;
        }
        else if (spotTag.Equals("h4"))
        {
            return attack4;
        }
        else if (spotTag.Equals("h5"))
        {
            return attack5;
        }
        else if (spotTag.Equals("h6"))
        {
            return attack6;
        }
        else if (spotTag.Equals("h7"))
        {
            return attack7;
        }
        else if (spotTag.Equals("h8"))
        {
            return attack8;
        }
        return null;
    }
    public GameObject[] GetHotbarArray()
    {
        GameObject[] myArray = {attack0, attack1, attack2, attack3, attack4, attack5, attack6, attack7, attack8};
        return myArray;
    }
    public void UpdatePrevItem(int curPoint)
    {
        attackLibrary currentAttack = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("attacks"))
        {
            if (obj.GetComponent<attackLibrary>() != null)
            {
                currentAttack = obj.GetComponent<attackLibrary>();
            }
        }
        try
        {
            savedValuesArr[currentAttack.cooldownSpot, curPoint] = cooldownArr[curPoint];
            if (curPoint == 0 && currentAttack != null && attack0 != null)
            {
                for(int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 0] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 1 && currentAttack != null && attack1 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 1] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 2 && currentAttack != null && attack2 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 2] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 3 && currentAttack != null && attack3 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 3] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 4 && currentAttack != null && attack4 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 4] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 5 && currentAttack != null && attack5 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 5] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 6 && currentAttack != null && attack6 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 6] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 7 && currentAttack != null && attack7 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 7] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
            else if (curPoint == 8 && currentAttack != null && attack8 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    savedValuesArr[i, 8] = currentAttack.GetComponent<attackLibrary>().GetSavedValues()[i];
                }
            }
        }catch(Exception e)
        {
            debugger += e;
        }
    }

    public void UpdateCurrentItem(int curPoint)
    {
        attackLibrary currentAttack = null;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("attacks"))
        {
            if (obj.GetComponent<attackLibrary>() != null)
            {
                currentAttack = obj.GetComponent<attackLibrary>();
                currentAttack.SetSavedValuesAtSpot(currentAttack.cooldownSpot, cooldownArr[curPoint]);
            }
        }
        try
        {
            savedValuesArr[currentAttack.cooldownSpot, curPoint] = cooldownArr[curPoint];
            if (curPoint == 0 && currentAttack != null && attack0 != null)
            {
                attack0.GetComponent<attackLibrary>().SetSavedValuesAtSpot(currentAttack.cooldownSpot, cooldownArr[curPoint]);
                for (int i = 0; i < 10; i++)
                {
                    attack0.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 0]);
                }
            }
            else if (curPoint == 1 && currentAttack != null && attack1 != null)
            {
                attack1.GetComponent<attackLibrary>().SetSavedValuesAtSpot(currentAttack.cooldownSpot, cooldownArr[curPoint]);
                for (int i = 0; i < 10; i++)
                {
                    if(i!= currentAttack.cooldownSpot)
                    attack1.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 1]);
                }
            }
            else if (curPoint == 2 && currentAttack != null && attack2 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack2.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 2]);
                }
            }
            else if (curPoint == 3 && currentAttack != null && attack3 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack3.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 3]);
                }
            }
            else if (curPoint == 4 && currentAttack != null && attack4 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack4.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 4]);
                }
            }
            else if (curPoint == 5 && currentAttack != null && attack5 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack5.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 5]);
                }
            }
            else if (curPoint == 6 && currentAttack != null && attack6 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack6.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 6]);
                }
            }
            else if (curPoint == 7 && currentAttack != null && attack7 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack7.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 7]);
                }
            }
            else if (curPoint == 8 && currentAttack != null && attack8 != null)
            {
                for (int i = 0; i < 10; i++)
                {
                    attack8.GetComponent<attackLibrary>().SetSavedValuesAtSpot(i, savedValuesArr[i, 8]);
                }
            }
        }
        catch (Exception e)
        {
            debugger += e;
        }
    }
    void UpdateCooldown(int hotBarSpot, bool isInScene)
    {
        attackLibrary currentAttack = null;
        float cooldownVal = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("attacks"))
        {
            if (obj.GetComponent<attackLibrary>() != null && isInScene)
            {
                currentAttack = obj.GetComponent<attackLibrary>();
                cooldownVal = currentAttack.GetSavedValues()[currentAttack.cooldownSpot];
                cooldownArr[hotBarSpot] = cooldownVal;
            }
            else
            {
                cooldownVal = cooldownArr[hotBarSpot];
            }
            //Debug.Log(attack0.GetComponent<attackLibrary>().GetSavedValues()[attack0.GetComponent<attackLibrary>().cooldownSpot] + " Index: " + cooldownArr[0]);
        }
        if (hotBarSpot == 0)
        {
            GameObject.FindGameObjectWithTag("h0").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }else if (hotBarSpot == 1)
        {
            GameObject.FindGameObjectWithTag("h1").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
        else if (hotBarSpot == 2)
        {
            GameObject.FindGameObjectWithTag("h2").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
        else if (hotBarSpot == 3)
        {
            GameObject.FindGameObjectWithTag("h3").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
        else if (hotBarSpot == 4)
        {
            GameObject.FindGameObjectWithTag("h4").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
        else if (hotBarSpot == 5)
        {
            GameObject.FindGameObjectWithTag("h5").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
        else if (hotBarSpot == 6)
        {
            GameObject.FindGameObjectWithTag("h6").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
        else if (hotBarSpot == 7)
        {
            GameObject.FindGameObjectWithTag("h7").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
        else if (hotBarSpot == 8)
        {
            GameObject.FindGameObjectWithTag("h8").GetComponent<Image>().fillAmount = 1 - cooldownVal;
        }
    }
    void UpdateCooldownIcons()
    {
        try
        {
            for (int i = 0; i < 9; i++)
            {
                UpdateCooldown(i, i==currentPoint);
            }
        }
        catch(Exception e)
        {
            debugger += e;
        }
    }
    public bool IsOnCooldown()
    {
        for(int i = 0; i < cooldownArr.Length; i++)
        {
            if (cooldownArr[i] < 1&& cooldownArr[i] != 0)
                return true;
        }
        float cooldownVal = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("attacks"))
        {
            if (obj.GetComponent<attackLibrary>() != null)
            {
                cooldownVal = obj.GetComponent<attackLibrary>().GetSavedValues()[obj.GetComponent<attackLibrary>().cooldownSpot];
            }
        }
        if (cooldownVal < 1 && cooldownVal != 0)
            return true;
        return false;
    }
}

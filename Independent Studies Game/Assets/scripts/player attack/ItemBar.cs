using System.Collections;
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
    attackLibrary lib0, lib1, lib2, lib3, lib4, lib5, lib6, lib7, lib8;
    [SerializeField]
    public int pointer;
    int currentPoint;
	float switchTimer;
	public bool justSwitched;
    bool justStarted;
    String debugger;
    PlayerMovement pM;
    bool updateNeeded;
	// Use this for initialization
	void Start () {
        updateAttacks();
        pointer = 0;
        currentPoint = 0;
        justStarted = true;
        debugger = "";
        updateNeeded = false;
        pM = GameObject.FindGameObjectWithTag("Player").GetComponent(typeof(PlayerMovement)) as PlayerMovement;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        updateAttacks();
        changeAttacks();
        setAttacks();
        setHotbarSelect();
        if (pM.doCommunicate)
        {
            attack8 = pM.recentPickUp;
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
    }
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
    //updates the attacks to account for any changes
    void updateAttacks()
    {
        //IMPORTANT!!!! in order to use try/catch, you need to first import it bby typing "using System" at the top
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
    void changeAttacks()
    {
        if (Input.GetKey(KeyCode.Alpha1)) pointer = 0;
        if (Input.GetKey(KeyCode.Alpha2)) pointer = 1;
        if (Input.GetKey(KeyCode.Alpha3)) pointer = 2;
        if (Input.GetKey(KeyCode.Alpha4)) pointer = 3;
        if (Input.GetKey(KeyCode.Alpha5)) pointer = 4;
        if (Input.GetKey(KeyCode.Alpha6)) pointer = 5;
        if (Input.GetKey(KeyCode.Alpha7)) pointer = 6;
        if (Input.GetKey(KeyCode.Alpha8)) pointer = 7;
        if (Input.GetKey(KeyCode.Alpha9)) pointer = 8;
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (pointer < 8)
            {
                pointer++;
            }
            else
                pointer = 0;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (pointer > 0)
            {
                pointer--;
            }
            else
                pointer = 8;
        }
    }
    void setAttacks()
    {
        GameObject[] attacks = GameObject.FindGameObjectsWithTag("attacks");
        if (justStarted)
        {
            //destroys all objects with the attack tag, which is found above ^
            foreach(GameObject obj in attacks) Destroy(obj);
            try{
                //creates a variable of the prefab, and then uses attacklibrary variables in them to set the positions
                var attackInst = Instantiate(attack0);
                attackInst.transform.parent = gameObject.transform;
                attackInst.transform.localPosition = lib0.pos;
                attackInst.transform.rotation = gameObject.transform.rotation;
                attackInst.transform.localRotation = Quaternion.Euler(lib0.rotX, lib0.rotY, lib0.rotZ);
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
                if (updateNeeded) updateNeeded = false;
            }
            catch (Exception e)
            {
                debugger += "\n" + e;
            }
            currentPoint = 8;
        }
    }
    public bool IsFull()
    {
        return (attack0 != null && attack1 != null && attack2 != null && attack3 != null && attack4 != null && attack5 != null && attack6 != null && attack7 != null && attack8 != null);
    }
}

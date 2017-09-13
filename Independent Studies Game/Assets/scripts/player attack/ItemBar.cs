using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    //the actual array of attacks we will be using
    GameObject[] attacks = new GameObject[9];
    [SerializeField]
    public int pointer;
    int currentPoint;
    bool justStarted;
	// Use this for initialization
	void Start () {
        updateAttacks();
        pointer = 0;
        currentPoint = 0;
        justStarted = true;
    }
	
	// Update is called once per frame
	void Update () {
        updateAttacks();
        changeAttacks();
        setAttacks();
    }
    //updates the attacks to account for any changes
    void updateAttacks()
    {
        attacks[0] = attack0;
        attacks[1] = attack1;
        attacks[2] = attack2;
        attacks[3] = attack3;
        attacks[4] = attack4;
        attacks[5] = attack5;
        attacks[6] = attack6;
        attacks[7] = attack7;
        attacks[8] = attack8;
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
        //if (Input.mouseScrollDelta > 0) pointer = Mathf.Min(0, Mathf.Max(8, pointer++));
    }
    void setAttacks()
    {
        GameObject[] attacks = GameObject.FindGameObjectsWithTag("attacks");
        if (justStarted)
        {
            foreach(GameObject obj in attacks) Destroy(obj);
            var attackInst = Instantiate(attack0);
            attackInst.transform.parent = gameObject.transform;
            attackInst.transform.localPosition = new Vector3(1.27f, -.7f, .889f);
            attackInst.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(pointer == 0 && currentPoint != 0 && !justStarted)
        {
            foreach (GameObject obj in attacks) Destroy(obj);
            Instantiate(attack0);
        }
        if (pointer == 1 && currentPoint != 1 && !justStarted)
        {
            foreach (GameObject obj in attacks) Destroy(obj);
            Instantiate(attack1);
        }
    }
}

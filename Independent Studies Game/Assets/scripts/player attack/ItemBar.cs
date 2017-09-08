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
	// Use this for initialization
	void Start () {
        updateAttacks();
    }
	
	// Update is called once per frame
	void Update () {
        updateAttacks();
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaNumber : MonoBehaviour {
    PlayerMana pMana;
	// Use this for initialization
	void Start () {
        pMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
    }
	
	// Update is called once per frame
	void Update () {
        int mana = (int) pMana.currMana;
        gameObject.GetComponent<Text>().text = ""+mana;
	}
}

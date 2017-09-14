using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour {
    public float startMana;
    public float currMana;
    public Slider manaSlider;
	// Use this for initialization
	void Start () {
        startMana = 100;
        currMana = startMana;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        manaSlider.value = currMana;

        if(currMana < startMana)
        {
            currMana += .1f;
        }
	}
}

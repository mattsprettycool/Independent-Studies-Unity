using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour {
    public float startMana;
    public float currMana;
    public Slider manaSlider;
    public bool refreshCooldown;
    public float cooldown;
	// Use this for initialization
	void Start () {
        startMana = 100;
        currMana = startMana;
        refreshCooldown = false;
        cooldown = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        manaSlider.value = currMana;
        if (refreshCooldown)
        {
            cooldown = 10f;
            refreshCooldown = false;
        }
        if (currMana < startMana && cooldown <= 0)
        {
            currMana += 1.5f;
        }
        else if(cooldown>0)
            cooldown -= .1f;
        if (currMana > 100) currMana = 100;
        if (cooldown < 0) cooldown = 0;
    }
}

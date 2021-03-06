﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Jai Saka
public class PlayerHealth : MonoBehaviour {
    public float startHealth;
    public float currHealth;
    public Slider healthSlider;
	bool dead;
	PlayerOnGround pog;
    PlayerMovement pMvmnt;
    bool damageTaken, canBeHurt, weaponBlocking;
	string debug;
	// Use this for initialization
	void Start () {
		canBeHurt = true;
		weaponBlocking = false;
		pMvmnt = gameObject.GetComponent<PlayerMovement> ();
		pog = gameObject.GetComponentInChildren<PlayerOnGround> ();
		if (PlayerPrefs.GetFloat ("health") != 0) {
			startHealth = PlayerPrefs.GetFloat ("health");
			currHealth = startHealth;
		} else {
			startHealth = 100;
			currHealth = startHealth;
		}
		dead = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		healthSlider.maxValue = startHealth;
        healthSlider.value = currHealth;
		//StunPlayerAfterAirtime (TimeInAir ());
		//added below for debuggin purposes
		if (Input.GetKey(KeyCode.K)) {
			currHealth = 0;
		}
		if (currHealth <= 0) {
			dead = true;
		}
    }

    //To be called upon by other methods, don't bother applying it here
    public void TakeDamage(float dmg)
    {
        currHealth -= dmg;
    }

	private void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "EnemyProjectiles" || col.gameObject.tag == "enemyweapon")
		{
			try
			{
				currHealth -= col.gameObject.GetComponent<ProjectileDamageLibrary>().dmgPerHit;
			}
			catch (Exception e)
			{
				debug += "\n" + e;
			}
		}
	}

	public void SetHurtable (bool val)
	{
		canBeHurt = val;
	}

	public bool GetHurtable ()
	{
		return canBeHurt;
	}

	public void SetBlocking (bool val)
	{
		weaponBlocking = val;
	}

	public bool GetBlocking ()
	{
		return weaponBlocking;
	}
	/*public float TimeInAir (){
		float timer = 0;
		if (pog.IsOnGround() == false) {
			timer += Time.deltaTime;
		}return timer;
	}
	void StunPlayerAfterAirtime (float timeInAir){
		if (timeInAir > 2) {
            pMvmnt.stunned = true;
		}
	}*/
	public bool DeadOrAlive () {
		return dead;
	}
}
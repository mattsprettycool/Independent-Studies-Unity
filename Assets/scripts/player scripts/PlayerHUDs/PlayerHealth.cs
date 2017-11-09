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
	public PlayerOnGround pog;
    bool damageTaken;
	string debug;
	// Use this for initialization
	void Start () {
		pog = gameObject.GetComponentInChildren<PlayerOnGround> ();
        startHealth = 100;
        currHealth = startHealth;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        healthSlider.value = currHealth;
		ApplyFallDamage (TimeInAir ());
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
	public float TimeInAir (){
		if (!pog.IsOnGround()) {
			float timer = 0;
			while (!pog.IsOnGround()) {
				timer += Time.deltaTime;
			}return timer;
		}return 0;
	}
	void ApplyFallDamage (float timeInAir){
		if (timeInAir > 2) {
			currHealth -= timeInAir * 5;
		}
	}
}

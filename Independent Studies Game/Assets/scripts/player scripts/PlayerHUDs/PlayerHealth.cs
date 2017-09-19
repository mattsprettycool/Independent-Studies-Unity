using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Jai Saka
public class PlayerHealth : MonoBehaviour {
    public int startHealth;
    public int currHealth;
    public Slider healthSlider;
    bool damageTaken;
	string debug;
    PlayerMovement playerMovement;
	// Use this for initialization
	void Start () {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        startHealth = 100;
        currHealth = startHealth;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        healthSlider.value = currHealth;
        //Sets movement speed to 0 once health reaches 0, disabling movement
        if (currHealth == 0)
        {
            playerMovement.speed = 0;   
        }
    }

    //To be called upon by other methods, don't bother applying it here
    public void TakeDamage(int dmg)
    {
        currHealth -= dmg;
    }

	private void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "projectiles")
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
}

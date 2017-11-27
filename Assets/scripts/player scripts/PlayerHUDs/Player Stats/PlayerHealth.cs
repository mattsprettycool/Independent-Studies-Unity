using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Jai Saka
public class PlayerHealth : MonoBehaviour {
    public float startHealth;
    public float currHealth;
    public Slider healthSlider;
	PlayerOnGround pog;
    PlayerMovement pMvmnt;
    bool damageTaken;
	string debug;
	// Use this for initialization
	void Start () {
		pog = gameObject.GetComponentInChildren<PlayerOnGround> ();
		if (PlayerPrefs.GetFloat ("health") != 0) {
			startHealth = PlayerPrefs.GetFloat ("health");
			currHealth = startHealth;
		} else {
			startHealth = 100;
			currHealth = startHealth;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        healthSlider.value = currHealth;
		StunPlayerAfterAirtime (TimeInAir ());
		//added below for debuggin purposes
		if (Input.GetKey(KeyCode.K)) {
			currHealth = 0;
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
	public float TimeInAir (){
		float timer = 0;
		if (pog.IsOnGround().Equals(false)) {
			timer += Time.deltaTime;
		}return timer;
	}
	void StunPlayerAfterAirtime (float timeInAir){
		if (timeInAir > 2) {
            pMvmnt.stunned = true;
		}
	}
}
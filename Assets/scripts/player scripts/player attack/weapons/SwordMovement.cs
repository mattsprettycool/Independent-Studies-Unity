using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class SwordMovement : MonoBehaviour {
	[SerializeField] 
	PlayerStamina playerStamina;
	PlayerMana pMana;
	PlayerHealth pHealth;
	AttackDamageLibrary adl;
	ItemBar itmBar;
	public bool attacking;
	string debug;
	public bool canBlock;
	float blockResetTimer;
	bool resetting;
	public int pressedR;
	// Use this for initialization
	void Start () {
		blockResetTimer = 0;
		canBlock = true;
		attacking = false;
		playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
		pMana = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMana> ();
		pHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		adl = gameObject.GetComponent<AttackDamageLibrary> ();
		itmBar = GameObject.FindGameObjectWithTag ("ItemBarHolder").GetComponent<ItemBar>();
		pressedR = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !attacking && playerStamina.currStamina >= 5 && Time.timeScale == 1f)
        {
			playerStamina.currStamina -= 5;
            StartCoroutine(SlashAndWait(.5f));
        }
		if (Input.GetMouseButton (1) && canBlock) {
			playerStamina.SetStaminaDrain (true, .1f);
			pHealth.SetBlocking (canBlock);
			transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 90));
		}
		if (Input.GetMouseButtonUp (1) || !canBlock) {
			playerStamina.SetStaminaDrain (false, 0f);
			pHealth.SetBlocking (canBlock);
			transform.localRotation = Quaternion.Euler (new Vector3 (0, -90, 0));
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			pressedR++;
			if (pressedR % 2 == 1 && playerStamina.currStamina > 0) {
				playerStamina.SetStaminaDrain (true, .5f);
				adl.SetDamage (50);
				adl.SetBleedDamage (1f);
			}
			if (pressedR % 2 == 0) {
				playerStamina.SetStaminaDrain (false, 0f);
				adl.SetDamage (25);
				adl.SetBleedDamage (.5f);
			}
		}
		if (canBlock = false) {
			resetting = true;
			blockResetTimer += Time.deltaTime;
			if (blockResetTimer > 1) {
				canBlock = true;
				blockResetTimer = 0;
				resetting = false;
			}
		}
		if (!attacking && playerStamina.currStamina > 0 && !resetting) {
			canBlock = true;
		} else {
			canBlock = false;
		}

		/*if (Input.GetKeyDown(KeyCode.F) && itmBar.GetHotbarArray() && pMana.currMana > 0){
			adl.SetDamage (20);
			adl.SetBleedDamage (.5f);
			pMana.InitiateDecrease(true);
		}
		if (pMana.currMana <= 0) {
			pMana.InitiateDecrease (false);
		}*/
    }

    IEnumerator SlashAndWait(float seconds)
    {
		attacking = true;
		gameObject.transform.Rotate (0, 0, -90);
		yield return new WaitForSeconds (seconds);
        gameObject.transform.Rotate(0, 0, 90);
		attacking = false;
    }

	void OnTriggerEnter(Collider col){
		if (col.tag == "Enemies" && attacking) {
			try {
				col.GetComponent<EnemyHealth> ().TakeDamage (gameObject.GetComponent<AttackDamageLibrary> ().dmgPerHit);
				col.GetComponent<EnemyHealth> ().bleeding = true;
				col.GetComponent<EnemyHealth> ().bleedDmg = gameObject.GetComponent<AttackDamageLibrary> ().bleedDamage;
			}
			catch(Exception e){
				debug += "\n" + e;
			}
		}
	}
}

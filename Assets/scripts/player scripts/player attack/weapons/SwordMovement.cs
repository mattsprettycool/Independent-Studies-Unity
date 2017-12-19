using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class SwordMovement : MonoBehaviour {
	PlayerStamina playerStamina;
	PlayerMana pMana;
	AttackDamageLibrary adl;
	ItemBar itmBar;
	public bool attacking;
	string debug;
	// Use this for initialization
	void Start () {
		attacking = false;
		playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
		pMana = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMana> ();
		adl = gameObject.GetComponent<AttackDamageLibrary> ();
		itmBar = GameObject.FindGameObjectWithTag ("ItemBarHolder").GetComponent<ItemBar>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !attacking && playerStamina.currStamina >= 10 && Time.timeScale == 1f)
        {
			
			playerStamina.currStamina -= 5;
			attacking = true;
            StartCoroutine(SlashAndWait(.5f));
			attacking = false;
        }
		/*if (Input.GetKeyDown(KeyCode.F) && itmBar.GetHotbarArray() && pMana.currMana > 0){
			adl.SetDamage (20);
			adl.SetBleedDamage (.5f);
			pMana.InitiateDecrease(true);
		}*/
    }

    IEnumerator SlashAndWait(float seconds)
    {
        gameObject.transform.Rotate(0, 0, -90);
        yield return new WaitForSeconds(seconds);
        gameObject.transform.Rotate(0, 0, 90);
    }

	void OnTriggerEnter(Collider col){
		if (col.tag == "Enemies") {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatButtonScript : MonoBehaviour {
	PlayerHealth pHealth;
	PlayerMana pMana;
	PlayerStamina pStamina;
	PlayerSpawn pSpawn;
	BonusesLibrary bLib;
	// Use this for initialization
	void Start(){
		pHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
		pMana = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMana> ();
		pStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
		pSpawn = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerSpawn> ();
		bLib = GameObject.FindGameObjectWithTag("Player").GetComponent<BonusesLibrary>();
	}
	public void IncreaseHealth(){
		if (pSpawn.GetPoints () > 0) {
			pHealth.startHealth += 10;
			pSpawn.SpendPoint ();
		}
		Debug.Log ("Clicked Health");
	}
	public void IncreaseStamina(){
		if (pSpawn.GetPoints () > 0) {
			pStamina.startStamina += 10;
			pSpawn.SpendPoint ();
		}
		Debug.Log ("Clicked Stamina");
	}
	public void DecreaseManaCoolDown(){
		if (pSpawn.GetPoints () > 0) {
			pMana.AddToCoolDownReduction (.5f);
			pSpawn.SpendPoint ();
		}
		Debug.Log ("Clicked Cooldown");
	}
	public void IncreaseMeleeBonus(){
		if (pSpawn.GetPoints () > 0) {
			bLib.AddToMagicBonusBy (2);
			pSpawn.SpendPoint ();
		}
		Debug.Log ("Clicked Melee Bonus");
	}
	public void IncreaseMagicBonus(){
		if (pSpawn.GetPoints () > 0) {
			bLib.AddToMagicBonusBy (2);
			pSpawn.SpendPoint ();
		}
		Debug.Log ("Clicked Magic Bonus");
	}
}

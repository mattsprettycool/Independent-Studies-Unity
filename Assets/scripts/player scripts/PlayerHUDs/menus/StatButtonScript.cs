using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
	void OnMouseOver(){
		if (gameObject.name == "HealthButton") {
			Debug.Log ("Hovercraft");
			GameObject.FindGameObjectWithTag ("HoverOverText").GetComponent<Text> ().text = "Health";
		}
		if (gameObject.name == "StaminaButton") {
			Debug.Log ("Hovercraft");
			GameObject.FindGameObjectWithTag ("HoverOverText").GetComponent<Text> ().text = "Stamina";
		}
		if (gameObject.name == "ManaCoolDownButton") {
			Debug.Log ("Hovercraft");
			GameObject.FindGameObjectWithTag ("HoverOverText").GetComponent<Text> ().text = "Mana Cooldown";
		}
		if (gameObject.name == "MagicAttackBonusButton") {
			Debug.Log ("Hovercraft");
			GameObject.FindGameObjectWithTag ("HoverOverText").GetComponent<Text> ().text = "Magic Attack Bonus";
		}
		if (gameObject.name == "MeleeAttackBonusButton") {
			Debug.Log ("Hovercraft");
			GameObject.FindGameObjectWithTag ("HoverOverText").GetComponent<Text> ().text = "Melee Attack Bonus";
		}
	}
}

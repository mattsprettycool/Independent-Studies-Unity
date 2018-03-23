using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusesLibrary : MonoBehaviour {
	public int meleeDmgBonus;
	public int spellDmgBonus;

	void Start(){
		if (PlayerPrefs.GetInt ("meleeBonus") != null) {
			meleeDmgBonus = PlayerPrefs.GetInt ("meleeBonus");
		} else {
			meleeDmgBonus = 0;
		}
	}

	public void SetMeleeBonus(int amount){
		meleeDmgBonus = amount;
	}

	public void SetMagicBonus(int amount){
		spellDmgBonus = amount;
	}
	public void AddToMeleeBonusBy(int amount){
		meleeDmgBonus += amount;
	}

	public void AddToMagicBonusBy(int amount){
		spellDmgBonus += amount;
	}
}
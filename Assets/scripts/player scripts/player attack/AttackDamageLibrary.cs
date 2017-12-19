using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamageLibrary : MonoBehaviour {
	public int dmgPerHit;
	public float bleedDamage;

	public void SetDamage(int toBe){
		dmgPerHit = toBe;
	}
	public void SetBleedDamage(float toBe){
		bleedDamage = toBe;
	}
}

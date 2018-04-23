using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealerScript : MonoBehaviour {
	void OnTriggerStay (Collider col){
		if (col.tag == "Enemies" && col.GetComponent<EnemyHealth>().currHealth < 100) {
			col.GetComponent<EnemyHealth> ().currHealth += .001f;						
		}
	}
}
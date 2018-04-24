using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealerScript : MonoBehaviour {
	void OnTriggerStay (Collider col){
		if (col.tag == "Enemies" && col.GetComponent<EnemyHealth>().currHealth < col.GetComponent<EnemyHealth>().startHealth && col.gameObject != this.gameObject.GetComponentInParent<Transform>().gameObject) {
			Debug.Log ("Healing: " + col.gameObject.transform.position + "Target has: " +  col.GetComponent<EnemyHealth>().currHealth + " health");
			col.GetComponent<EnemyHealth> ().currHealth += .01f;						
		}
	}
}
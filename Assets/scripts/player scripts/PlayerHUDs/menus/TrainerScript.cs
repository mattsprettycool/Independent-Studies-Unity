using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainerScript : MonoBehaviour {
	StatMenu statM;
	// Use this for initialization
	void Start(){
		statM = GameObject.FindGameObjectWithTag ("StatMenu").GetComponent<StatMenu> ();
	}
	void OnTriggerStay (Collider col){
		if (col.gameObject.tag == "Player" && !statM.GetActive()) {
			Debug.Log ("Set active!");
			statM.SetActive (true);
		}
	}
	void OnTriggerExit (Collider col){
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Unset active!");
			statM.SetActive (false);
		}
	}
}

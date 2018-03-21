using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour {
	bool active;
	bool canBeUsed;
	PlayerSpawn pSpawn;
	// Use this for initialization
	void Start () {
		active = false;
		canBeUsed = false;
		pSpawn = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerSpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!active) {
			gameObject.GetComponent<Image> ().enabled = false;
			foreach (Text t in gameObject.GetComponentsInChildren<Text>()) {
				t.enabled = false;
			}
			foreach (Image i in gameObject.GetComponentsInChildren<Image>()) {
				i.enabled = false;
			}
		}
		if (active) {
			gameObject.GetComponent<Image> ().enabled = true;
			foreach (Text t in gameObject.GetComponentsInChildren<Text>()) {
				t.enabled = true;
			}
			foreach (Image i in gameObject.GetComponentsInChildren<Image>()) {
				i.enabled = true;
			}
		}
	}

	public void SetActive (bool tf){
		active = tf;
	}

	public bool GetActive () {
		return active;
	}
}

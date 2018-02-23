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
		if (Input.GetKeyDown (KeyCode.Tab) && !pSpawn.inArena) {
			active = true;
		}
	}
}

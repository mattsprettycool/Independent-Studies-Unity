using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenu : MonoBehaviour {
	bool active;
	PlayerSpawn pSpawn;
	// Use this for initialization
	void Start () {
		active = false;
		pSpawn = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerSpawn> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!active && Time.timeScale != 0) {
			gameObject.GetComponent<Image> ().enabled = false;
			Cursor.lockState = CursorLockMode.Locked;
			foreach (Text t in gameObject.GetComponentsInChildren<Text>()) {
				t.enabled = false;
			}
			foreach (Image i in gameObject.GetComponentsInChildren<Image>()) {
				i.enabled = false;
			}
			foreach (Button b in gameObject.GetComponentsInChildren<Button>()) {
				b.enabled = false;
			}
		}
		if (active && Time.timeScale != 0) {
			gameObject.GetComponent<Image> ().enabled = true;
			Cursor.lockState = CursorLockMode.None;
			foreach (Text t in gameObject.GetComponentsInChildren<Text>()) {
				t.enabled = true;
			}
			foreach (Image i in gameObject.GetComponentsInChildren<Image>()) {
				i.enabled = true;
			}
			foreach (Button b in gameObject.GetComponentsInChildren<Button>()) {
				b.enabled = true;
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

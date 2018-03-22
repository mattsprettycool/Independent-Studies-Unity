using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : MonoBehaviour {
	SpellManager spm;
	public GameObject projectile;
	float size;
	// Use this for initialization
	void Start () {
		spm = gameObject.GetComponent<SpellManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Mouse0)) {
			size += .05f;
		}
		if (Input.GetKeyUp (KeyCode.Mouse0) && spm.HasManaNumber () && Time.timeScale == 1f) {
			for (int i = 0; i < 12; i++){
				GameObject proj = Instantiate (projectile, gameObject.transform);
				proj.GetComponent<Transform> ().transform.localScale = new Vector3 (.1f + (size/10), .1f + (size/10), .1f + (size/10));
				proj.GetComponent<Transform> ().localPosition = new Vector3 (0, 0, 0);
				proj.GetComponent<Transform> ().Rotate (Random.Range (-7.5f, 7.5f), Random.Range (-7.5f, 7.5f), 0);
				proj.GetComponent<Transform> ().SetParent (null);
			}spm.LoseMana (); spm.SetManaCooldown(); size = 0;
		}
	}
}

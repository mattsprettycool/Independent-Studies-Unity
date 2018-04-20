using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadShot : MonoBehaviour {
	SpellManager spm;
	PlayerMana pMana;
	public GameObject projectile;
	float size;
	// Use this for initialization
	void Start () {
		spm = gameObject.GetComponent<SpellManager> ();
		pMana = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMana> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Mouse0) && spm.HasManaNumber () && Time.timeScale == 1f && spm.IsOffCooldown()) {
			spm.LoseMana (); spm.SetManaCooldown(); spm.SetSpellCooldown ();
			for (int i = 0; i < 12; i++){
				GameObject proj = Instantiate (projectile, gameObject.transform);
				proj.GetComponent<Transform> ().transform.localScale = new Vector3 (.1f, .1f, .1f);
				proj.GetComponent<Transform> ().localPosition = new Vector3 (0, 0, 0);
				proj.GetComponent<Transform> ().Rotate (Random.Range (-7.5f, 7.5f), Random.Range (-7.5f, 7.5f), 0);
				proj.GetComponent<Transform> ().SetParent (null);
			}
		}
		if (spm.IsOffCooldown())
		{
			gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(1, 1);
		}
		else
			gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(1, 0);
		gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(0, spm.GetCooldownRatio());
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Jai Saka
public class PlayerStamina : MonoBehaviour {
	public float startStamina;
	public float currStamina;
	public Slider staminaSlider;
	PlayerStats pStats;
	// Use this for initialization
	void Start () {
		pStats = gameObject.GetComponent<PlayerStats> ();
		startStamina = pStats.baseStamina;
		currStamina = startStamina;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		staminaSlider.value = currStamina;

		if (currStamina < startStamina)
        {
			currStamina += .1f;
		}
	}
}
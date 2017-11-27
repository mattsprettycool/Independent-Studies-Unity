using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Jai Saka
public class PlayerStamina : MonoBehaviour {
	public float startStamina;
	public float currStamina;
	public Slider staminaSlider;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetFloat ("stamina") != 0) {
			startStamina = PlayerPrefs.GetFloat ("stamina");
			currStamina = startStamina;
		} else {
			startStamina = 100;
			currStamina = startStamina;
		}
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
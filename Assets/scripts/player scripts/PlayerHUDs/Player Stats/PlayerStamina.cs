using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Jai Saka
public class PlayerStamina : MonoBehaviour {
	public float startStamina;
	public float currStamina;
	float staminaDrain;
	bool draining;
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
		staminaDrain = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		staminaSlider.maxValue = startStamina;
		staminaSlider.value = currStamina;
		if (draining) {
			currStamina -= staminaDrain;
		}
		if (currStamina < startStamina && !draining)
        {
			currStamina += .1f;
		}
		if (currStamina < 0) {
			currStamina = 0;
		}
	}

	public void SetStaminaDrain(bool isDraining, float stamDrain){
		draining = isDraining;
		staminaDrain = stamDrain;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMana : MonoBehaviour {
    public float startMana;
    public float currMana;
    public Slider manaSlider;
    public bool refreshCooldown;
    public float cooldown;
    public float cooldownReduction;
    bool decreasing;
    public float maxMana;
    // Use this for initialization
    void Start() {
        decreasing = false;
        if (PlayerPrefs.GetFloat("mana") != 0) {
            startMana = PlayerPrefs.GetFloat("mana");
            currMana = startMana;
            maxMana = startMana;
        } else {
            startMana = 100;
            currMana = startMana;
            maxMana = startMana;
        }
        refreshCooldown = false;
        cooldown = 0;
        cooldownReduction = 0;
        StartCoroutine(DecreaseMana());
    }

    // Update is called once per frame
    void FixedUpdate() {
        maxMana = startMana;
        manaSlider.value = currMana;
        if (refreshCooldown)
        {
            cooldown = 10f - (cooldownReduction * .5f);
            refreshCooldown = false;
        }
        if (currMana < maxMana && cooldown <= 0)
        {
            currMana += 1.5f;
        }
        else if (cooldown > 0)
            cooldown -= .1f;
        if (currMana > maxMana) currMana = maxMana;
        if (cooldown < 0) cooldown = 0;
    }

    public void StartCooldown(float cooldownTime)
    {
        cooldown = cooldownTime - (cooldownReduction*.5f);
    }
    public float GetMaxMana()
    {
        return maxMana;
    }
    public float GetCurrentMana()
    {
        return currMana;
    }

    //what is this jai
	public IEnumerator DecreaseMana(){
		while (true) {
			if (decreasing) {
				currMana -= 1;
				yield return new WaitForSeconds (.5f);
			}
			yield return null;
		}
	}
    //WHAT IS THIS JAI
	public void InitiateDecrease(bool yesNo){
		decreasing = true;
	}
}

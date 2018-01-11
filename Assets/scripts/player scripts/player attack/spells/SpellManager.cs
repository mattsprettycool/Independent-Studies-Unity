using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpellManager : MonoBehaviour {
    PlayerMana playerMana;
    bool isOffCooldown = true;
    float currCooldownTime = 0;
    [SerializeField]
    float defaultManaCooldown = 0, defaultSpellCooldown = 0, defaultManaCost = 0;
	void Start () {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
	}
    private void FixedUpdate()
    {
        if (!isOffCooldown&&currCooldownTime>0)
        {
            currCooldownTime--;
        }else if (!isOffCooldown)
        {
            currCooldownTime = 0;
            isOffCooldown = true;
        }
    }
    public void SetManaCooldown()
    {
        playerMana.StartCooldown(defaultManaCooldown);
    }
    public void SetManaCooldown(float cooldownTime)
    {
        playerMana.StartCooldown(cooldownTime);
    }
    public void SetSpellCooldown()
    {
        currCooldownTime = defaultSpellCooldown;
        isOffCooldown = false;
    }
    public void SetSpellCooldown(float cooldownTime)
    {
        currCooldownTime = cooldownTime;
        isOffCooldown = false;
    }
    public bool IsOffCooldown()
    {
        return isOffCooldown;
    }
    public void LoseMana()
    {
        playerMana.currMana -= defaultManaCost;
    }
    public void LoseMana(float manaToLose)
    {
        playerMana.currMana -= manaToLose;
    }
    public bool HasManaPercent(float percentAsDecimal)
    {
        return ((playerMana.GetCurrentMana())/playerMana.GetMaxMana())>=percentAsDecimal && (((playerMana.GetCurrentMana() - (defaultManaCost * (playerMana.GetCurrentMana() / playerMana.GetMaxMana()))) / playerMana.GetMaxMana()) >= 0);
    }
    public bool HasManaNumber()
    {
        return (playerMana.GetCurrentMana() >= defaultManaCost) && ((playerMana.GetCurrentMana() - defaultManaCost)>=0);
    }
    public bool HasManaNumber(float manaAmmount)
    {
        return (playerMana.GetCurrentMana()) >= manaAmmount && ((playerMana.GetCurrentMana() - manaAmmount) >= 0);
    }
    public bool HasManaPercent(float percentAsDecimal, float manaToLose)
    {
        return ((playerMana.GetCurrentMana()) / playerMana.GetMaxMana()) >= percentAsDecimal && ((playerMana.GetCurrentMana() - (manaToLose * (playerMana.GetCurrentMana() / playerMana.GetMaxMana()))) >= 0);
    }
    public bool HasManaNumber(float manaAmmount, float manaToLose)
    {

        return (playerMana.GetCurrentMana()) >= manaAmmount && ((playerMana.GetCurrentMana() - manaToLose)>=0);
    }
}

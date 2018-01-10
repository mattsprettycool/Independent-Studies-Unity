using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpellManager : MonoBehaviour {
    PlayerMana playerMana;
    [SerializeField]
    float defaultManaCooldown = 0, defaultSpellCooldown = 0, defaultManaCost = 0;
	void Start () {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
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

    }
    public void SetSpellCooldown(float cooldownTime)
    {

    }
    public void LoseMana()
    {
        playerMana.currMana -= defaultManaCost;
    }
    public void LoseMana(float manaToLose)
    {
        playerMana.currMana -= manaToLose;
    }
    public bool HasManaPercent(float percentAsDecimal, bool useDefaultManaCost)
    {

        return true;
    }
    public bool HasManaNumber(float manaAmmount, bool useDefaultManaCost)
    {

        return true;
    }
    public bool HasManaPercent(float percentAsDecimal, float manaToLose)
    {

        return true;
    }
    public bool HasManaNumber(float manaAmmount, float manaToLose)
    {

        return true;
    }
}

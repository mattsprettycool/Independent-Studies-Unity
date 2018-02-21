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
    /// <summary>
    /// Starts the mana cooldown time based on the default mana cost value
    /// </summary>
    public void SetManaCooldown()
    {
        playerMana.StartCooldown(defaultManaCooldown);
    }
    /// <summary>
    /// Starts the mana cooldown time based on the float you input
    /// </summary>
    /// <param name="cooldownTime">Time to wait before regeneration kicks in for mana</param>
    public void SetManaCooldown(float cooldownTime)
    {
        playerMana.StartCooldown(cooldownTime);
    }
    /// <summary>
    /// Prevents the spell from being used for the default time
    /// </summary>
    public void SetSpellCooldown()
    {
        currCooldownTime = defaultSpellCooldown;
        isOffCooldown = false;
    }
    /// <summary>
    /// Prevents the spell to be used for the specified time
    /// </summary>
    /// <param name="cooldownTime">Time to keep the spell on cooldown</param>
    public void SetSpellCooldown(float cooldownTime)
    {
        currCooldownTime = cooldownTime;
        isOffCooldown = false;
    }
    /// <summary>
    /// Returns a value based on if the spell is on or off cooldown
    /// </summary>
    /// <returns>A boolean; if true: not on cooldown, if false: on cooldown</returns>
    public bool IsOffCooldown()
    {
        return isOffCooldown;
    }
    /// <summary>
    /// Gets the ratio of cooldown to default cooldown from 0 - 1
    /// </summary>
    /// <returns>a float from 0 to 1 based on the ratio of current cooldown to the default cooldown</returns>
    public float GetCooldownRatio()
    {
        if (currCooldownTime > defaultSpellCooldown)
            return 1;
        return (currCooldownTime/defaultSpellCooldown);
    }
    /// <summary>
    /// removes the default mana cost from the mana pool
    /// </summary>
    public void LoseMana()
    {
        playerMana.currMana -= defaultManaCost;
    }
    /// <summary>
    /// removes the specified ammount from the mana pool
    /// </summary>
    /// <param name="manaToLose">Mana to remove</param>
    public void LoseMana(float manaToLose)
    {
        playerMana.currMana -= manaToLose;
    }
    /// <summary>
    /// Checks if the mana pool has more than or has the specified percentage of mana
    /// </summary>
    /// <param name="percentAsDecimal">The percent of mana as a decimal ex: 45% would be .45</param>
    /// <returns>True if the mana pool has that percent of mana</returns>
    public bool HasManaPercent(float percentAsDecimal)
    {
        return ((playerMana.GetCurrentMana())/playerMana.GetMaxMana())>=percentAsDecimal && (((playerMana.GetCurrentMana() - (defaultManaCost * (playerMana.GetCurrentMana() / playerMana.GetMaxMana()))) / playerMana.GetMaxMana()) >= 0);
    }
    /// <summary>
    /// Checks if the mana pool has more than or has the specified number of mana, taken from the default mana cost
    /// </summary>
    /// <returns>True if the mana pool has that number of mana</returns>
    public bool HasManaNumber()
    {
        return (playerMana.GetCurrentMana() >= defaultManaCost) && ((playerMana.GetCurrentMana() - defaultManaCost)>=0);
    }
    /// <summary>
    /// Checks if the mana pool has more than or has the specified number of mana
    /// </summary>
    /// <param name="manaAmmount">The ammount of mana to check for</param>
    /// <returns>True if the mana pool has that number of mana</returns>
    public bool HasManaNumber(float manaAmmount)
    {
        return (playerMana.GetCurrentMana()) >= manaAmmount && ((playerMana.GetCurrentMana() - manaAmmount) >= 0);
    }
    /// <summary>
    /// Checks if the mana pool has more than or has the specified percentage of mana
    /// </summary>
    /// <param name="percentAsDecimal">The percent of mana as a decimal ex: 45% would be .45</param>
    /// <param name="manaToLose">mana to lose</param>
    /// <returns>True if the mana pool has that percent of mana</returns>
    public bool HasManaPercent(float percentAsDecimal, float manaToLose)
    {
        return ((playerMana.GetCurrentMana()) / playerMana.GetMaxMana()) >= percentAsDecimal && ((playerMana.GetCurrentMana() - (manaToLose * (playerMana.GetCurrentMana() / playerMana.GetMaxMana()))) >= 0);
    }
    /// <summary>
    /// Checks if the mana pool has more than or has the specified percentage of mana
    /// </summary>
    /// <param name="manaAmmount">ammount of mana to test for</param>
    /// <param name="manaToLose">mana to lose</param>
    /// <returns>True if the mana pool has that number of mana</returns>
    public bool HasManaNumber(float manaAmmount, float manaToLose)
    {

        return (playerMana.GetCurrentMana()) >= manaAmmount && ((playerMana.GetCurrentMana() - manaToLose)>=0);
    }
}

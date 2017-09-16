using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaNumber : MonoBehaviour
{
    PlayerStamina pStamina;
    // Use this for initialization
    void Start()
    {
        pStamina = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStamina>();
    }

    // Update is called once per frame
    void Update()
    {
        int stamina = (int)pStamina.currStamina;
        gameObject.GetComponent<Text>().text = "" + stamina;
    }
}

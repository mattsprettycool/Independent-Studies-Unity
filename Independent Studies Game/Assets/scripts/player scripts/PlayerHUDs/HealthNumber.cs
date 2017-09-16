using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthNumber : MonoBehaviour
{
    PlayerHealth pHealth;
    // Use this for initialization
    void Start()
    {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = (int)pHealth.currHealth;
        gameObject.GetComponent<Text>().text = "" + health;
    }
}

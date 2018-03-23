using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTurret : MonoBehaviour {
    [SerializeField]
    float timeUntilStart = 0;
    float curTime = 0;
    [SerializeField]
    GameObject projectile;
    private void Start()
    {
        curTime = timeUntilStart;
    }
    private void FixedUpdate()
    {
        if (curTime > 0)
        {
            curTime--;
        }
        else
        {
            ShootEnemy();
        }
    }
    void ShootEnemy()
    {
        var proj = Instantiate(projectile);
        proj.transform.position = GameObject.FindGameObjectWithTag("Enemies").GetComponent<Transform>().position;
        AddCooldown(250);
    }
    void AddCooldown(float x)
    {
        curTime += x;
    }
}

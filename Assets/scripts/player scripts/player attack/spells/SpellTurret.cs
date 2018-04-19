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
    [SerializeField]
    float timeUntilDeath = 100;
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
        if (timeUntilDeath > 0)
        {
            timeUntilDeath--;
        }
        else
            Destroy(gameObject);
    }
    void ShootEnemy()
    {
        if (GameObject.FindGameObjectWithTag("Enemies") != null)
        {
            GameObject foundEnemy = GameObject.FindGameObjectWithTag("Enemies");
            var proj = Instantiate(projectile);
            proj.transform.position = new Vector3(transform.position.x, transform.position.y+ 1.733f, transform.position.z);
            proj.transform.LookAt(foundEnemy.transform);
            AddCooldown(5);
        }
    }
    void AddCooldown(float x)
    {
        curTime += x;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GravityWell : MonoBehaviour
{
    [SerializeField]
    public GameObject gravAOE;
    [SerializeField]
    public GameObject fakeGravAOE;
    PlayerMana playerMana;
    // Use this for initialization
    void Start()
    {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerMana.currMana >= 100 && Time.timeScale == 1f)
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo))
            {
                playerMana.currMana -= 100;
                playerMana.refreshCooldown = true;
                var attackInst = Instantiate(gravAOE);
                attackInst.transform.position = new Vector3(hitInfo.point.x, 1.266f, hitInfo.point.z);
            }
        }
        else
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo)&&playerMana.currMana >=100)
            {
                if (hitInfo.collider.tag == "Floor")
                {
                    Destroy(GameObject.FindGameObjectWithTag("gravAoe"));
                    var attackInst = Instantiate(fakeGravAOE);
                    attackInst.transform.position = new Vector3(hitInfo.point.x, 1.266f, hitInfo.point.z);
                }
                else
                {
                    try
                    {
                        Destroy(GameObject.FindGameObjectWithTag("gravAoe"));
                    }
                    catch(Exception e)
                    {
                        Debug.Log(e);
                    }
                }
            }else
                try
                {
                    Destroy(GameObject.FindGameObjectWithTag("gravAoe"));
                }
                catch (Exception e)
                {
                    Debug.Log(e);
                }
            if(Input.GetKey(KeyCode.Alpha0)|| Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha5) || Input.GetKey(KeyCode.Alpha6) || Input.GetKey(KeyCode.Alpha7) || Input.GetKey(KeyCode.Alpha8) || Input.GetKey(KeyCode.Alpha9) || Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                Destroy(GameObject.FindGameObjectWithTag("gravAoe"));
            }
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Someone
public class HeadBob : MonoBehaviour {
    float sineWaveSlice, timer, midway = .51f;
    GameObject player, cameraLoc;
    [SerializeField]
    float bobSpeed, bobIncrement = 0;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cameraLoc = GameObject.FindGameObjectWithTag("ItemBarHolder");
    }
    void Update()
    {
        if (Time.timeScale == 1f)
        {
            GameObject camLoc = GameObject.FindGameObjectWithTag("camRef");
            gameObject.transform.position = new Vector3(camLoc.transform.position.x, camLoc.transform.position.y, camLoc.transform.position.z);
            midway = player.transform.position.y + .51f;
            sineWaveSlice = 0f;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
            {
                timer = 0;
            }
            else
            {
                sineWaveSlice = Mathf.Sin(timer);
                //Debug.Log(sineWaveSlice);
                timer += bobSpeed;
                if (timer > Mathf.PI * 2)
                {
                    timer -= Mathf.PI * 2;
                }
            }
            //if (sineWaveSlice != 0 && player.GetComponent<PlayerMovement>().IsInAir()) {
            if (sineWaveSlice != 0 && !player.GetComponent<PlayerMovement>().IsInAir())
            {
                float translateVal = sineWaveSlice * bobIncrement;
                float totalAxes = Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical"));
                totalAxes = Mathf.Clamp(totalAxes, 0, 1);
                translateVal = totalAxes * translateVal;
                float yVal = midway + translateVal;
                transform.localPosition = new Vector3(cameraLoc.transform.position.x, yVal, cameraLoc.transform.position.z);
                transform.rotation = Camera.main.transform.rotation;
            }
            else
            {
                transform.localPosition = new Vector3(cameraLoc.transform.position.x, midway, cameraLoc.transform.position.z);
                transform.rotation = Camera.main.transform.rotation;
            }
        }
    }
	}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopObject : MonoBehaviour {
    ArtificialTimeManager realTime;
    bool timeOn = false;
    float timeForSpell = 250, currTime = 0;
    // Use this for initialization
    void Start () {
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currTime < timeForSpell)
            {
            realTime.SetTime(false);
            currTime++;
            }
        else
            {
                realTime.SetTime(true);
                Destroy(gameObject);
            }
        
    }
}

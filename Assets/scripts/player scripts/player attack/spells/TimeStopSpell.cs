using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopSpell : MonoBehaviour {
    ArtificialTimeManager realTime;
    bool timeOn;
    SpellManager spellMan;
    float timeForSpell = 100, currTime = 0;
    [SerializeField]
    GameObject timeDrop;
	// Use this for initialization
	void Start () {
        spellMan = gameObject.GetComponent<SpellManager>();
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        timeOn = realTime.IsTimeOn();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var i = Instantiate(timeDrop);
            i.transform.position = gameObject.transform.position;
            i.transform.rotation = gameObject.transform.rotation;
        }
        if (!timeOn)
        {
            if (currTime < timeForSpell)
            {
                currTime++;
            }
            else
            {
                timeOn = true;
                currTime = 0;
            }
        }
        realTime.SetTime(timeOn);
	}
}

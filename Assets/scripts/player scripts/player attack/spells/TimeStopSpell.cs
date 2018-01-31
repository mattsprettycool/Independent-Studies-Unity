using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopSpell : MonoBehaviour {
    ArtificialTimeManager realTime;
    bool timeOn;
    SpellManager spellMan;
    [SerializeField]
    GameObject timeDrop;
    int timeAlive = 0;
	// Use this for initialization
	void Start () {
        spellMan = gameObject.GetComponent<SpellManager>();
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        timeOn = realTime.IsTimeOn();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log(timeAlive);
        //timeAlive++;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var i = Instantiate(timeDrop);
            i.transform.position = gameObject.transform.position;
            i.transform.rotation = gameObject.transform.rotation;
        }
	}
}

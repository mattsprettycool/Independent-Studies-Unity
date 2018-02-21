using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStopSpell : MonoBehaviour {
    ArtificialTimeManager realTime;
    bool timeOn;
    SpellManager spellMan;
    [SerializeField]
    GameObject timeDrop;
    public int timeAlive = 0;
	// Use this for initialization
	void Start () {
        spellMan = gameObject.GetComponent<SpellManager>();
        realTime = GameObject.FindGameObjectWithTag("Player").GetComponent<ArtificialTimeManager>();
        timeOn = realTime.IsTimeOn();
        timeAlive = (int)gameObject.GetComponent<attackLibrary>().GetSavedValues()[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Mouse0)&&spellMan.IsOffCooldown())
        {
            spellMan.SetSpellCooldown();
            var i = Instantiate(timeDrop);
            i.transform.position = gameObject.transform.position;
            i.transform.rotation = gameObject.transform.rotation;
        }
        if (spellMan.IsOffCooldown())
        {
            gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(0, 1);
        }
        else
            gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(0, 0);
        gameObject.GetComponent<attackLibrary>().SetSavedValuesAtSpot(1, spellMan.GetCooldownRatio());
    }
}

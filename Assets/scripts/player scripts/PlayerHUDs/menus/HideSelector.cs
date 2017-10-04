using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//by Matt Braden
public class HideSelector : MonoBehaviour {
    
	void FixedUpdate () {
        gameObject.GetComponent<Image>().enabled = false;
	}
}

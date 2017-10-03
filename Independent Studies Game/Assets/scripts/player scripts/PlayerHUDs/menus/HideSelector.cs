using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideSelector : MonoBehaviour {
    
	void FixedUpdate () {
        gameObject.GetComponent<Image>().enabled = false;
	}
}

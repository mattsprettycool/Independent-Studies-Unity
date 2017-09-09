using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour {

    bool slashing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && !slashing)
        {
            slashing = true;
            StartCoroutine(SlashAndWait(.5f));
            slashing = false;
        }
    }

    IEnumerator SlashAndWait(float seconds)
    {
        gameObject.transform.Rotate(0, 0, -90);
        yield return new WaitForSeconds(seconds);
        gameObject.transform.Rotate(0, 0, 90);
    }
}

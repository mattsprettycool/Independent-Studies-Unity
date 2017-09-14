using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class SwordMovement : MonoBehaviour {

    bool slashing;
	PlayerStamina playerStamina;
	// Use this for initialization
	void Start () {
		playerStamina = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStamina> ();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && !slashing)
        {
			playerStamina.currStamina -= 10;
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

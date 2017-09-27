using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMovement : MonoBehaviour {
	public bool slashing;
	// Use this for initialization
	public void Start (){
		SlashAndWaitSpear (2.5f);
	}

	IEnumerator SlashAndWaitSpear (float seconds)
	{
		slashing = true;
		gameObject.transform.Rotate(0, 0, -90);
		yield return new WaitForSeconds(seconds);
		gameObject.transform.Rotate(0, 0, 90);
		slashing = false;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour {
	float sineWaveSlice,timer,boobSpeed,boobIncrement,midway,logHorizon,vertical;
	void Update () {
		midway = .51f;
		sineWaveSlice = 0f;
		logHorizon = Input.GetAxis ("Horizontal");
		vertical = Input.GetAxis ("Vertical");
		if (Mathf.Abs (logHorizon) == 0 && Mathf.Abs (vertical) == 0) {
			timer = 0;
		} else {
			sineWaveSlice = Mathf.Sin (timer);
			timer += boobSpeed;
			if (timer > Mathf.PI * 2) {
				timer -= Mathf.PI * 2;
			}
		}
		if (sineWaveSlice != 0) {
			float translateVal = sineWaveSlice * boobIncrement;
			float totalAxes = Mathf.Abs (logHorizon) + Mathf.Abs (vertical);
			totalAxes = Mathf.Clamp (totalAxes, 0, 1);
			translateVal = totalAxes * translateVal;
			float yVal = midway + translateVal;
			transform.localPosition = new Vector3 (transform.localPosition.x, yVal, transform.localPosition.z);
		} else { 
			transform.localPosition = new Vector3 (transform.localPosition.x, midway, transform.localPosition.z);
		}
	}
}

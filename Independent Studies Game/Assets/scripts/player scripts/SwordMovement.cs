using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMovement : MonoBehaviour {

    [SerializeField]
    public GameObject sword;
    float xpos;
    float ypos;
    float zpos;
    bool slashing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        xpos = sword.transform.position.x;
        ypos = sword.transform.position.y;
        zpos = sword.transform.position.z;
        if (Input.GetMouseButtonDown(0) && slashing != true)
        {
            slashing = true;
            StartCoroutine(SlashAndWait(.5f));
            slashing = false;
        }
    }

    IEnumerator SlashAndWait(float seconds)
    {
        sword.transform.Rotate(0, 0, -90);
        yield return new WaitForSeconds(seconds);
        sword.transform.Rotate(0, 0, 90);
    }
}

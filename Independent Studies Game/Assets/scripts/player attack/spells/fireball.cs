using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
    [SerializeField]
    public GameObject firebolt;
    PlayerMana playerMana;
	// Use this for initialization
	void Start () {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0) && playerMana.currMana >= 10)
        {
            playerMana.currMana -= 10;
            var attackInst = Instantiate(firebolt);
            attackInst.transform.parent = gameObject.transform;
            attackInst.transform.localPosition = new Vector3(0f, 0f, 0f);
            attackInst.transform.rotation = gameObject.transform.rotation;
            attackInst.transform.localRotation = Quaternion.Euler(0, -90, 0);
            attackInst.transform.localPosition = new Vector3(0f, 0f, .75f);
            attackInst.transform.SetParent(null);
        }
	}
}

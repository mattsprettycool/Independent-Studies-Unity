using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    [SerializeField]
    public GameObject gravAOE;
    PlayerMana playerMana;
    // Use this for initialization
    void Start()
    {
        playerMana = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && playerMana.currMana >= 100 && Time.timeScale == 1f)
        {
            playerMana.currMana -= 100;
            playerMana.refreshCooldown = true;
            var attackInst = Instantiate(gravAOE);
            //attackInst.transform.parent = gameObject.transform;
            //attackInst.transform.localPosition = new Vector3(0f, 0f, 0f);
            //attackInst.transform.rotation = gameObject.transform.rotation;
            //attackInst.transform.localRotation = Quaternion.Euler(0, -90, 0);
            //attackInst.transform.localPosition = new Vector3(0f, 0f, .75f);
            //attackInst.transform.SetParent(null);
        }
        else
        {
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAOEEffect : MonoBehaviour {
    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Enemies")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(.5f);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemies")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(.5f);
        }
    }
}

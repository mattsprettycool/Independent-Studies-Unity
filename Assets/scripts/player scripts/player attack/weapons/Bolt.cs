using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Jai Saka
public class Bolt : MonoBehaviour {
    [SerializeField]
    float timer;
    float timeBeforeDeletion;
    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        timer = 0;
        timeBeforeDeletion = 7;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(375, 0, 0));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (timer >= timeBeforeDeletion)
        {
            GameObject.Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
        gameObject.GetComponent<ProjectileDamageLibrary>().travelTime += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "attacks")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}

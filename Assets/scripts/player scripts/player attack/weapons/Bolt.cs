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
        timeBeforeDeletion = 7f;
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(new Vector3(500f, 0f, 0f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (timer >= timeBeforeDeletion)
        {
            GameObject.Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player" && other.tag != "attacks")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}

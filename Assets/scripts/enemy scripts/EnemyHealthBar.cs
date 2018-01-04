using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class EnemyHealthBar : MonoBehaviour {
    [SerializeField, Range(0.0f, 1.0f)]
    float health = 1;
    float baseHealth = 1;
    float rectWidth = 0;
    float rectBackWidth = 0;
    Transform rectangle;
    Transform recBack;
    // Use this for initialization
    void Start()
    {
        Component[] objArr = gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform obj in objArr)
        {
            if (obj.tag.Equals("healthBar"))
            {
                rectWidth = obj.localScale.x;
                rectangle = obj;
            }
            else if (obj.tag.Equals("ehealthback"))
            {
                recBack = obj;
                rectBackWidth = recBack.localScale.x;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponent<EnemyHealth>().GetHealth() / 100.0f;
        baseHealth = gameObject.GetComponent<EnemyHealth>().GetBaseHealth() / 100.0f;
        rectangle.localScale = new Vector3(rectWidth * health, rectangle.transform.localScale.y, 1);
        recBack.localScale = new Vector3(rectBackWidth * baseHealth, recBack.localScale.y, 1);
        rectangle.transform.rotation = recBack.transform.rotation;
    }
}

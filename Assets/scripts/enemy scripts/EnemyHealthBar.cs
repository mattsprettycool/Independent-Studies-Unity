using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class EnemyHealthBar : MonoBehaviour {
    [SerializeField, Range(0.0f, 1.0f)]
    float health = 1;
    float rectWidth = 0;
    Transform rectangle;
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
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponent<EnemyHealth>().GetHealth() / 100.0f;
        rectangle.localScale = new Vector3(rectWidth * health, rectangle.transform.localScale.y, 1);
    }
}

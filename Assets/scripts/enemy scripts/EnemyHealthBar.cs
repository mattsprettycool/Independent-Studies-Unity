using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class EnemyHealthBar : MonoBehaviour {
    [SerializeField, Range(0.0f, 1.0f)]
    float health = 1;
    float rectWidth = 0;
    GameObject rectangle;
    // Use this for initialization
    void Start()
    {
        foreach(GameObject obj in gameObject.GetComponentsInChildren<GameObject>())
        {
            if (obj.tag.Equals("healthBar"))
            {
                rectWidth = obj.transform.localScale.y;
                rectangle = obj.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        rectangle.transform.localScale = new Vector3(.9f, rectWidth * health, 1);
    }
}

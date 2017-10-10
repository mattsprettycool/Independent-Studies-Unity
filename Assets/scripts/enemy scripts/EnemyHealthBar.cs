using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Matt Braden
public class EnemyHealthBar : MonoBehaviour {
    [SerializeField, Range(0.0f, 1.0f)]
    float health;
    float rectHeight;
    // Use this for initialization
    void Start()
    {
        foreach(GameObject obj in gameObject.GetComponentsInChildren<GameObject>())
        {
            //if(obj.tag.Equals("healthBar"))

        }
        rectHeight = gameObject.GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().rect.width, rectHeight * health);
    }
}

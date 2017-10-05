using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellPickup : MonoBehaviour {
    [SerializeField]
    public GameObject prefabToCopy;
    ItemBar iBar;
    InventoryScreen iScreen;
    // Use this for initialization
    void Start () {
        gameObject.GetComponent<SpriteRenderer>().sprite = prefabToCopy.GetComponent<attackLibrary>().icon;
        iBar = Camera.main.GetComponent<ItemBar>();
        iScreen = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        gameObject.transform.LookAt(Camera.main.transform);
	}
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && !iBar.IsFull())
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Player" && !iScreen.IsFull())
        {
            Destroy(gameObject);
        }
    }
}

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
        Init();
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
    public void SetPrefab(GameObject g)
    {
        prefabToCopy = g;
        Init();
    }
    void Init()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = prefabToCopy.GetComponent<attackLibrary>().icon;
        iBar = GameObject.FindGameObjectWithTag("ItemBarHolder").GetComponent<ItemBar>();
        iScreen = GameObject.FindGameObjectWithTag("UI").GetComponent<InventoryScreen>();
    }
}

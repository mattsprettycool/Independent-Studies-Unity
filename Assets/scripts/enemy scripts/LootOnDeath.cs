using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootOnDeath : MonoBehaviour {
    EnemyHealth eh;
    [SerializeField]
    GameObject drops, itemDrop;
    int itemsInArray = 0;
    attackLibrary[] attacks;
	// Use this for initialization
	void Start () {
        int i = 0;
        eh = gameObject.GetComponent<EnemyHealth>();
        foreach (attackLibrary obj in drops.GetComponentsInChildren<attackLibrary>())
        {
            itemsInArray++;
        }
        attacks = new attackLibrary[itemsInArray];
        foreach (attackLibrary obj in drops.GetComponentsInChildren<attackLibrary>())
        {
            attacks[i] = obj;
            i++;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (eh.IsDead())
        {
            DropLoot();
        }
	}
    void DropLoot()
    {
        int randy = Random.Range(0, itemsInArray - 1);
        itemDrop.GetComponent<spellPickup>().SetPrefab(attacks[randy].gameObject);
        Instantiate(itemDrop);
    }
}

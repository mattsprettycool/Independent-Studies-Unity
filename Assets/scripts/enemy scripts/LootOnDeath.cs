using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootOnDeath : MonoBehaviour {
    EnemyHealth eh;
    [SerializeField]
    GameObject drops, itemDrop;
    int itemsInArray = 0;
    attackLibrary[] attacks;
    [SerializeField, Range(.01f, 1)]
    float probRatioForLoot = .1f;
	// Use this for initialization
	void Start () {
        int i = 0;
        eh = gameObject.GetComponent<EnemyHealth>();
        foreach (GameObject obj in drops.GetComponent<ItemsInLootPool>().GetDroppableArray())
        {
            itemsInArray++;
        }
        attacks = new attackLibrary[itemsInArray];
        foreach (GameObject obj in drops.GetComponent<ItemsInLootPool>().GetDroppableArray())
        {
            attacks[i] = obj.GetComponent<attackLibrary>();
            i++;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (eh.IsDead())
        {
            DropLoot();
        }
	}
    void DropLoot()
    {
        if (Random.Range(1, probRatioForLoot*100) <= 1)
        {
            int randy = Random.Range(0, itemsInArray - 1);
            itemDrop.GetComponent<spellPickup>().SetPrefab(attacks[randy].gameObject);
            Instantiate(itemDrop, transform.position, transform.rotation);
        }
    }
}

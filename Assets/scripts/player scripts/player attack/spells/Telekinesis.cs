using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Telekinesis : MonoBehaviour {
    Transform currentlySelectedEnemy;
    SpellManager spellManager;
    // Use this for initialization
    void Start () {
        spellManager = gameObject.GetComponent<SpellManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) && spellManager.HasManaNumber() && Time.timeScale == 1f)
        {
            spellManager.LoseMana();
            spellManager.SetManaCooldown();
            foreach (GameObject obj in GetAllNearEnemies(25))
            {
                Vector3 pushDir = Camera.main.transform.position - obj.transform.position;
                obj.GetComponent<NavMeshAgent>().velocity = -Vector3.Normalize(pushDir)*20;
            }
        }
    }

    GameObject[] GetAllNearEnemies(float maxDist)
    {
        LinkedList<GameObject> linkGame = new LinkedList<GameObject>();
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemies"))
        {
            if ((GetDistance(transform.position.x, transform.position.z, obj.transform.position.x, obj.transform.position.z) <= maxDist))
                linkGame.AddLast(obj);
        }
        GameObject[] gameArr = new GameObject[linkGame.Count];
        int i = 0;
        foreach(GameObject obj in linkGame)
        {
            gameArr[i] = obj;
            i++;
        }
        return gameArr;
    }

    float GetDistance(float myX, float myZ, float theirX, float theirZ)
    {
        return Mathf.Sqrt(Mathf.Pow((myX-theirX),2)+ Mathf.Pow((myZ - theirZ), 2));
    }
}

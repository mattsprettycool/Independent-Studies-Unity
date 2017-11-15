using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour {
    [SerializeField]
	public Transform[] spawnPoints;
	public string[] levelList;
    string currLevel;
	PlayerHealth pHealth;
	MusicController musicCont;
	GameObject playerSpawnTrigger;
    KillManager killMngr;
	int randy;
	public int arenaIndex;
	public bool inArena;
	// Use this for initialization
	void Start () {
		pHealth = gameObject.GetComponent<PlayerHealth> ();
		musicCont = gameObject.GetComponent<MusicController> ();
		playerSpawnTrigger = GameObject.FindGameObjectWithTag ("PlayerSpawnTrigger");
		inArena = true;
        currLevel = SceneManager.GetActiveScene().name;
		musicCont.PlaySong (inArena);
	}
	
	// Update is called once per frame
	void Update () {
		playerSpawnTrigger.transform.Rotate (new Vector3 (playerSpawnTrigger.transform.rotation.x, playerSpawnTrigger.transform.rotation.y + 15, playerSpawnTrigger.transform.rotation.z));
		if (pHealth.currHealth == 0)
		{
			transform.position = new Vector3 (2, 102, 0);
			pHealth.currHealth = pHealth.startHealth;
			inArena = false;
			musicCont.PlaySong (inArena);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "PlayerSpawnTrigger") {
			randy = Random.Range (0, spawnPoints.Length);
			arenaIndex = Random.Range (0, levelList.Length);
			Debug.Log ("Loading: " + levelList [arenaIndex]);
            currLevel = levelList[arenaIndex];
			SceneManager.LoadScene (levelList[arenaIndex]);
		}
	}
    public string GetCurrentScene()
    {
        return currLevel;
    }
}

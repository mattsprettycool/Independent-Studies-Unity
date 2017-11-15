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
	EnemySpawn enSpawn;
	int randy;
	public int arenaIndex;
	public bool inArena;
	// Use this for initialization
	void Start () {
		enSpawn = GameObject.FindGameObjectWithTag ("enemymanager").GetComponent<EnemySpawn> ();
		killMngr = GameObject.FindGameObjectWithTag ("killcounter").GetComponent<KillManager> ();
		pHealth = gameObject.GetComponent<PlayerHealth> ();
		musicCont = gameObject.GetComponent<MusicController> ();
		playerSpawnTrigger = GameObject.FindGameObjectWithTag ("PlayerSpawnTrigger");
		inArena = true;
		arenaIndex = 0;
		currLevel = levelList [arenaIndex];
		musicCont.PlaySong (inArena);
	}
	
	// Update is called once per frame
	void Update () {
		playerSpawnTrigger.transform.Rotate (new Vector3 (playerSpawnTrigger.transform.rotation.x, playerSpawnTrigger.transform.rotation.y + 15, playerSpawnTrigger.transform.rotation.z));
		if (pHealth.currHealth <= 0 || enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ())
		{
			transform.position = new Vector3 (2, 102, 0);
			pHealth.currHealth = pHealth.startHealth;
			inArena = false;
			musicCont.PlaySong (inArena);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "PlayerSpawnTrigger" && enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ()) {
			Debug.Log ("Met parameters");
			arenaIndex++;
			randy = Random.Range (0, spawnPoints.Length);
			Debug.Log ("Loading: " + levelList [arenaIndex]);
			currLevel = levelList [arenaIndex];
			SceneManager.LoadScene (levelList [arenaIndex]);
		}
		if (other.tag == "PlayerSpawnTrigger" && !(enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ())){
			Debug.Log ("Did not meet parameters");
			randy = Random.Range (0, spawnPoints.Length);
			Debug.Log ("Loading: " + levelList [0]);
			currLevel = levelList [0];
			SceneManager.LoadScene (levelList [0]);
		}
	}
    public string GetCurrentScene()
    {
        return currLevel;
    }
}

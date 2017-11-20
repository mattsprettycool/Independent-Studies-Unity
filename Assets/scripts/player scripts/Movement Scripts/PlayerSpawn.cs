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
	PlayerStats pStats;
	public GameObject playerSpawnTrigger;
    public KillManager killMngr;
	EnemySpawn enSpawn;
	int randy;
	public int arenaIndex;
	public bool inArena;
	// Use this for initialization
	void Start () {
		pStats = gameObject.GetComponent<PlayerStats> ();
		enSpawn = GameObject.FindGameObjectWithTag ("enemymanager").GetComponent<EnemySpawn> ();
		pHealth = gameObject.GetComponent<PlayerHealth> ();
		musicCont = gameObject.GetComponent<MusicController> ();
		inArena = true;
		arenaIndex = 0;
		currLevel = levelList [arenaIndex];
		musicCont.PlaySong (inArena);
	}
	
	// Update is called once per frame
	void Update () {
		playerSpawnTrigger.transform.Rotate (new Vector3 (playerSpawnTrigger.transform.rotation.x, playerSpawnTrigger.transform.rotation.y + 15, playerSpawnTrigger.transform.rotation.z));
		if (pHealth.currHealth <= 0 || enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded () && inArena)
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
			SceneManager.LoadScene (levelList [arenaIndex]);
		}
		if (other.tag == "PlayerSpawnTrigger" && !(enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ())){
			Debug.Log ("Did not meet parameters");
			arenaIndex = 0;
			randy = Random.Range (0, spawnPoints.Length);
			Debug.Log ("Loading: " + levelList [0]);
			SceneManager.LoadScene (levelList [0]);
		}
	}
    public string GetCurrentScene()
    {
		return levelList [arenaIndex];
    }
}

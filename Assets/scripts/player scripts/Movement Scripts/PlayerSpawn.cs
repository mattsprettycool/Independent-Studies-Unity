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
	PlayerStamina pStam;
	PlayerMana pMana;
	PlayerMovement pMove;
	MusicController musicCont;
	public GameObject playerSpawnTrigger;
    public KillManager killMngr;
	EnemySpawn enSpawn;
	public int arenaIndex;
	public bool inArena;
	float timer;
	int statPointsToSpend;
	// Use this for initialization
	void Start () {
		timer = 0;
		if (PlayerPrefs.GetInt ("points") != 0) {
			statPointsToSpend = PlayerPrefs.GetInt ("points");
		} else {
			statPointsToSpend = 0;
		}
		pHealth = gameObject.GetComponent<PlayerHealth> ();
		pStam = gameObject.GetComponent<PlayerStamina> ();
		pMana = gameObject.GetComponent<PlayerMana> ();
		pMove = gameObject.GetComponent<PlayerMovement> ();
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
		if (inArena) {
			timer += Time.deltaTime;
		}
		playerSpawnTrigger.transform.Rotate (new Vector3 (playerSpawnTrigger.transform.rotation.x, playerSpawnTrigger.transform.rotation.y + 15, playerSpawnTrigger.transform.rotation.z));
		if (pHealth.currHealth <= 0 || enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded () && inArena)
		{
			transform.position = new Vector3 (2, 102, 0);
			pHealth.currHealth = pHealth.startHealth;
			inArena = false;
			statPointsToSpend += 1 + (int)((timer / 60) / 2);
			musicCont.PlaySong (inArena);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.name == "HealthUp" && statPointsToSpend > 0) {
			pHealth.startHealth += 10;
			statPointsToSpend -= 1;
		}
		if (other.name == "ManaUp" && statPointsToSpend > 0) {
			pMana.startMana += 10;
			statPointsToSpend -= 1;
		}
		if (other.name == "StaminaUp" && statPointsToSpend > 0) {
			pStam.startStamina += 10;
			statPointsToSpend -= 1;
		}
		if (other.tag == "PlayerSpawnTrigger" && enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ()) {
			Debug.Log ("Met parameters");
			Debug.Log ("Saving Stats");
			SaveStats ();
			arenaIndex++;
			Debug.Log ("Loading: " + levelList [arenaIndex]);
			SceneManager.LoadScene (levelList [arenaIndex]);
		}
		if (other.tag == "PlayerSpawnTrigger" && !(enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ())){
			Debug.Log ("Did not meet parameters");
			Debug.Log ("Saving Stats");
			SaveStats ();
			arenaIndex = 0;
			Debug.Log ("Loading: " + levelList [0]);
			SceneManager.LoadScene (levelList [0]);
		}
	}
    public string GetCurrentScene()
    {
		return levelList [arenaIndex];
    }
	public void SaveStats()
	{
		PlayerPrefs.SetFloat ("health", pHealth.startHealth);
		PlayerPrefs.SetFloat ("stamina", pStam.startStamina);
		PlayerPrefs.SetFloat ("mana", pMana.startMana);
		PlayerPrefs.SetFloat ("speed", pMove.GetSpeed ());
		PlayerPrefs.SetInt ("points", statPointsToSpend);
		PlayerPrefs.Save ();
	}
	public bool GetArenaState(){
		return inArena;
	}
	public int GetPointsAvailable(){
		return statPointsToSpend;
	}
	void OnApplicationQuit(){
		PlayerPrefs.DeleteAll ();
	}
}

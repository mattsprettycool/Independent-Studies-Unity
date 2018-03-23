using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawn : MonoBehaviour {
    [SerializeField]
	public Transform[] spawnPoints;
	public string[] levelList;
    //string currLevel;
	PlayerHealth pHealth;
	PlayerStamina pStam;
	PlayerMana pMana;
	PlayerMovement pMove;
	MusicController musicCont;
	BonusesLibrary bl;
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
		bl = gameObject.GetComponent<BonusesLibrary> ();
		pMove = gameObject.GetComponent<PlayerMovement> ();
		enSpawn = GameObject.FindGameObjectWithTag ("enemymanager").GetComponent<EnemySpawn> ();
		pHealth = gameObject.GetComponent<PlayerHealth> ();
		musicCont = gameObject.GetComponent<MusicController> ();
		inArena = true;
		//arenaIndex = 0;
		//currlevel = levelList [arenaIndex];
		//musicCont.PlaySong (inArena);
	}
	
	// Update is called once per frame
	void Update () {
		if (inArena) {
			timer += Time.deltaTime;
		}
		if (pHealth.currHealth <= 0 || enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded () && inArena)
		{
			transform.position = GameObject.Find ("PlayerSpawnLoc").gameObject.transform.position;
			pHealth.currHealth = pHealth.startHealth;
			inArena = false;
			if (!pHealth.DeadOrAlive ()) {
				statPointsToSpend += 1 + (int)(1.1 - (timer/1000));
			}
			//musicCont.PlaySong (inArena);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "PlayerSpawnTrigger" && enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ()) {
			Debug.Log ("Met parameters");
			Debug.Log ("Saving Stats");
			SaveStats (pHealth.startHealth, pStam.startStamina, pMana.startMana, bl.spellDmgBonus,pMana.cooldownReduction, bl.meleeDmgBonus, pMove.GetSpeed(), statPointsToSpend);
			arenaIndex++;
			Debug.Log ("Loading: " + levelList [arenaIndex]);
			SceneManager.LoadScene (levelList [arenaIndex]);
		}
		if (other.tag == "PlayerSpawnTrigger" && !(enSpawn.GetEnemiesKilled () >= killMngr.GetKillsNeeded ())){
			Debug.Log ("Did not meet parameters");
			Debug.Log ("Saving Stats");
			SaveStats (100, 100, 100, 0, 0, 0, .2f, 0);
			arenaIndex = 0;
			Debug.Log ("Loading: " + levelList [0]);
			SceneManager.LoadScene (levelList [0]);
		}
	}
    public string GetCurrentScene()
    {
		return levelList [arenaIndex];
    }
	public void SaveStats(float health, float stamina, float mana, int magicDmgBonus, float manaCooldownReduction, int meleeDmgBonus, float movementSpeed, int statPoints)
	{
		PlayerPrefs.SetFloat ("health", health);
		PlayerPrefs.SetFloat ("stamina", stamina);
		PlayerPrefs.SetFloat ("mana", mana);
		PlayerPrefs.SetInt ("spellBonus", magicDmgBonus);
		PlayerPrefs.SetFloat ("manaCooldownReduction", manaCooldownReduction);
		PlayerPrefs.SetInt ("meleeBonus", meleeDmgBonus);
		PlayerPrefs.SetFloat ("speed", movementSpeed);
		PlayerPrefs.SetInt ("points", statPoints);
		PlayerPrefs.Save ();
	}
	public bool GetArenaState(){
		return inArena;
	}
	public int GetPointsAvailable(){
		return statPointsToSpend;
	}
    public bool GetPlayerInArena()
    {
        return inArena;
    }
	public void SpendPoint(){
		statPointsToSpend--;
	}
	public int GetPoints(){
		return statPointsToSpend;
	}
	void OnApplicationQuit(){
		PlayerPrefs.DeleteAll ();
	}
}

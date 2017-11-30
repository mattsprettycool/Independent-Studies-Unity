using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicController : MonoBehaviour {
	public AudioClip[] peaceSongs;
	public AudioClip[] warSongs;
	public AudioSource audSource;
	//public AudioMixerSnapshot transistor;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	public void PlaySong(bool inArena){
		if (inArena) {
			int randy = Random.Range (0, warSongs.Length);
			audSource.clip = warSongs [randy];
			//transistor.TransitionTo (1);
			//audSource.Play ();
		}
		if (!inArena) {
			int randy = Random.Range (0, peaceSongs.Length);
			audSource.clip = peaceSongs [randy];
			//transistor.TransitionTo (1);
			//audSource.Play ();
		}
	}
}

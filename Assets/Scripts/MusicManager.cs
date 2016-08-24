using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChange;
	
	private AudioSource audioSource;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		Debug.Log("dont destroy on load:" + name);
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChange[level];
		Debug.Log ("Playing clip: " + thisLevelMusic);
		
		if (thisLevelMusic) { //If there is some music
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
	
	public void SetVolume (float newVolume) {
		audioSource.volume = newVolume;
	}
}

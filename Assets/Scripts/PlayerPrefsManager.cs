using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFF_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	// level_unlocked_2/3/4... leave underscore

	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <= 1) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		}
		else {
		Debug.LogError ("Master Volume out of range!");
		}
	}
	
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel (int level) {
		if (level <= (Application.levelCount - 1)) { //Every level that is unlocked will have the 1 value, every that is not will have the 0 value
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString(), 1); //Use 1 for true because before it = "level_unlocked_(level.ToString)"
		}
		else {
			Debug.LogError ("Unlock level out of range!");
		}
	}
	
	public static bool IsLevelUnlocked (int level) {
		int levelValue = PlayerPrefs.GetInt (LEVEL_KEY + level.ToString()); //Gets the value from UnlockLevel which is 1 or 0
		bool isLevelUnlocked = (levelValue == 1); //1 if unlocked, 0 if locked
		
		if (level <= (Application.levelCount - 1)) {
			return isLevelUnlocked;
		}
		else {
			Debug.LogError ("Query level not in build order!");
			return false;
		}
	}
	
	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <= 3f) {
			PlayerPrefs.SetFloat (DIFF_KEY, difficulty);
		}
		else {
			Debug.LogError ("Difficulty out of range");
		}
	}
	
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat(DIFF_KEY);
	}
	
	
}

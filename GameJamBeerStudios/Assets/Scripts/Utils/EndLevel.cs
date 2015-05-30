using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	public string nextLevel;

	public void GoToMenu(){
		Application.LoadLevel ("SelectGames");
		Debug.Log ("go to menu");
	}

	public void GoToNextLevel(){
		Application.LoadLevel (nextLevel);
	}

	public void Exit(){
		Application.Quit();
	}

	public void RetryLevel(){
		Application.LoadLevel(Application.loadedLevelName);
	}
}

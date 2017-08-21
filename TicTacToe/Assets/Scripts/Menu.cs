using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

	public static string Level;

	public void GoToEasy(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
		Level = "Easy";
	}

	public void GoToNorm(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
		Level = "Normal";
	}

	public void GoToHard(){
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
		Level = "Hard";
	}

	public void Exit(){
		Application.Quit ();
	}
}

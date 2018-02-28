using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static GameManager manager;

	public Text scoreText;

	// Use this for initialization
	void Start () {
		if(SceneManager.GetActiveScene().name == "EndScreen"){
			if(scoreText != null){
				scoreText.text = Score.gameScore.ToString ();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeScene() {
		SceneManager.LoadScene ("LiftOffTesting");
	}

	public void changeScene2() {
		SceneManager.LoadScene ("LiftOffTesting");
	}

	public void changeScene3() {
		SceneManager.LoadScene ("InstructionsScreen");
	}

	public void changeScene4() {
		SceneManager.LoadScene ("StartScreen");
	}
}

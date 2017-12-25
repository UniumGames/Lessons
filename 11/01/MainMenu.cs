using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public Button startButton;
	public Button creditsButton;
	public Button exitButton;

	void Start() {
		startButton.onClick.AddListener(LoadGame);
		creditsButton.onClick.AddListener(LoadCredits);
		exitButton.onClick.AddListener(ExitGame);
	}

	void LoadGame() {
		SceneManager.LoadScene("Football");
	}

	void LoadCredits() {
		SceneManager.LoadScene("Credits");
	}

	void ExitGame() {
		Application.Quit();
	}
}

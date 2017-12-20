using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour {
	void Start() {
		Button button = GetComponent<Button>();
		button.onClick.AddListener(LoadCredits);
	}

	void LoadCredits() {
		SceneManager.LoadScene("Credits");
	}
}

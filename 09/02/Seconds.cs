using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seconds : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	double time = 0;
	void Update() {
		time = time + Time.deltaTime;
		int seconds = (int)time;
		print("Количество секунд: " + seconds);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seconds : MonoBehaviour {
	float time = 0;
	void Update() {
		time = time + Time.deltaTime;
		int seconds = (int)time;
		print("Количество секунд: " + seconds);
	}
}

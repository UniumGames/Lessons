using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour {
	double time = 0;
	float redComponent = 0;
	void Update() {
		time = time + Time.deltaTime;

		Renderer rend = GetComponent<Renderer>();
		redComponent = redComponent + 0.05f;
		rend.material.color = new Color(redComponent, 0, 0);
		if (time > 1) {
			time = 0;
			redComponent = 0;
		}
	}
}

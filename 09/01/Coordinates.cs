using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates : MonoBehaviour {

	void Start() {
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.x;
		print("Координаты: x = " + x + ", y = " + y + ", z = " + z);
	}

	void Update() {
	}
}

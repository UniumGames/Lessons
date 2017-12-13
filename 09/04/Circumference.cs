using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circumference : MonoBehaviour {

	void Start () {
		int radius = 371;
		float circumference = 2 * 3.14f * radius;
		print("Длина окружности с радиусом " + radius + " равна " + circumference);
	}
}

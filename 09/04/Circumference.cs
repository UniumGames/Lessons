using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circumference : MonoBehaviour {

	void Start () {
		int radius = 371;
		double circumference = 2 * 3.14 * radius;
		print("Длина окружности с радиусом " + radius + " равна " + circumference);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
	float time = 0;
	void Update() {
		time = time + Time.deltaTime;

		// если прошло больше 15 секунд
		if (time > 15) {
			// то перемещаемся в координаты (0, 0, 0)
			transform.position = new Vector3(0, 0, 0);
			// и начинаем отсчет заново
			time = 0;
		}
	}
}

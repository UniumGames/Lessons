using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour {
	float time = 0;
	void Update() {
		time = time + Time.deltaTime;

		// находим и сохраняем компонент рендерер,
		// в котором хранится материал
		Renderer rend = GetComponent<Renderer>();

		// после третьей секунды сбрасываем время на ноль,
		// чтобы начать заново с зеленого цвета.
		// в остальное время включаем нужный цвет
		if (time > 3) {
			time = 0;
		}
		else if (time > 2) {
			rend.material.color = Color.red;
		}
		else if (time > 1) {
			rend.material.color = Color.yellow;
		}
		else if (time > 0) {
			rend.material.color = Color.green;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHeight : MonoBehaviour {
	private float maxHeight = 0;
	void Update () {
		// если новая высота больше, чем максимальная
		if (transform.position.y > maxHeight) {
			// то новая высота становится максимальной
			maxHeight = transform.position.y;
		}
		print(maxHeight);
	}
}

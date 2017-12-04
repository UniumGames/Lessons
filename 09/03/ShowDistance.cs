using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDistance : MonoBehaviour {
	public Transform monster;

	// Use this for initialization
	void Start() {
		float dist = Vector3.Distance(monster.position, transform.position);
		print("Расстояние до монстра: " + dist);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

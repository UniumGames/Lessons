using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

	static float time = 0;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (Time.time - time > 2) {
				time = Time.time;
				if(!GetComponent<Rigidbody>().isKinematic){
					return;
				}

				var companion = GetComponent<CompanionStore>().companion;
				if (companion == null) {
					return;
				}
				other.transform.position = companion.transform.position;
			}
		}
	}
}

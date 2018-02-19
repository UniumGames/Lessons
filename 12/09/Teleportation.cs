using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.tag != "Player") {
			return;
		}

		Portal portalData = GetComponent<Portal>();
		if (portalData.isPlayerCaptured) {
			portalData.isPlayerCaptured = false;
			return;
		}

		if (!GetComponent<Rigidbody>().isKinematic) {
			return;
		}

		var companion = GetComponent<Portal>().companion;
		if (companion == null) {
			return;
		}

		other.transform.position = companion.transform.position;
		companion.GetComponent<Portal>().isPlayerCaptured = true;
	}
}

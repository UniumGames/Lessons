using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public GameObject bluePortal;
	public GameObject orangePortal;

	GameObject blueClone;
	GameObject orangeClone;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			Destroy(orangeClone);
			orangeClone = Instantiate(orangePortal, transform.position, transform.rotation);
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1)) {
			Destroy(blueClone);
			blueClone = Instantiate(bluePortal, transform.position, transform.rotation);
		}
		else {
			return;
		}

		if (orangeClone != null) {
			orangeClone.GetComponent<Portal>().companion = blueClone;
		}
		if (blueClone != null) {
			blueClone.GetComponent<Portal>().companion = orangeClone;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public GameObject bluePortal;
	public GameObject orangePortal;

	public GameObject blueClone;
	public GameObject orangeClone;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			Destroy(orangeClone);
			orangeClone = Instantiate(orangePortal, transform.position, transform.rotation);

			orangeClone.GetComponent<CompanionStore>().companion = blueClone;
			if(blueClone != null){
				blueClone.GetComponent<CompanionStore>().companion = orangeClone;
			}
		}
		else if (Input.GetKeyDown(KeyCode.Mouse1)) {
			Destroy(blueClone);
			blueClone = Instantiate(bluePortal, transform.position, transform.rotation);

			if(orangeClone != null){
				orangeClone.GetComponent<CompanionStore>().companion = blueClone;
			}
			blueClone.GetComponent<CompanionStore>().companion = orangeClone;
		}
	}
}

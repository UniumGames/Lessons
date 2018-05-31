using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHit : MonoBehaviour {
	void OnCollisionEnter(Collision collision) {
		var other = collision.collider;
		if (other.tag == "Active") {
			StartCoroutine(Enlarge(.2f));

			Rigidbody rb = GetComponent<Rigidbody>();
			rb.isKinematic = true;
			GetComponent<Collider>().isTrigger = true;

			foreach (ContactPoint contact in collision.contacts) {
				// развернем портал вдоль поверхности
				transform.rotation = Quaternion.LookRotation(contact.normal);
			}
		} else {
			Destroy(gameObject);
		}
	}

	private IEnumerator Enlarge(float duration) {
		float startTime = Time.time;
		Vector3 startingScale = transform.localScale;
		Vector3 endScale = new Vector3(3, 3, 1);
		while (Time.time - startTime < duration) {
			transform.localScale = Vector3.Lerp(startingScale, endScale, (Time.time - startTime) / duration);
			yield return null;
		}
		Destroy(this);
	}
}

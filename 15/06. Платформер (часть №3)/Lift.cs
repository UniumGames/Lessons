using UnityEngine;
using System.Collections;

public class Lift : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = transform;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null; 
    }
}

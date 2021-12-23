using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicOffWhenThrow : MonoBehaviour {
	public void TurnKinematicOff() {
		GetComponent<Rigidbody>().isKinematic = false;
	}
}
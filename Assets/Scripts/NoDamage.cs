using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDamage : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Laser1") || other.gameObject.CompareTag ("Laser2") || other.gameObject.CompareTag ("ChargeShot")) {
			Destroy (other.gameObject);
			Manager.instance.audioCenter.PlayOneShot (Manager.instance.noDamage);
		}
	}
}

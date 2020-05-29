using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStart : MonoBehaviour {
	public Camera bossCam;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			gameObject.SetActive (false);
			Manager.instance.musicCenter.clip = Manager.instance.bossA;
			Manager.instance.musicCenter.Play ();
			bossCam.GetComponent<CameraRotate> ().enabled = true;
		}
	}
}

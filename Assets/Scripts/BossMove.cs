using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {
	public int counter = -150;
	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	int orientation = 0;
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody>();
	}
	bool right = true;
	void Update () {
		counter += (int)(Time.deltaTime * 60);
		if (counter >= 30 && counter < 240) {
			if (door1 != null) {
				door1.GetComponent<DoorOpen> ().openDoor ();
			}
			if (door2 != null) {
				door2.GetComponent<DoorOpen> ().openDoor ();
			}
			if (door3 != null) {
				door3.GetComponent<DoorOpen> ().openDoor ();
			}
		}
		if (counter >= 240 && counter < 360) {
			if (door1 != null) {
				door1.GetComponent<DoorOpen> ().closeDoor ();
			}
			if (door2 != null) {
				door2.GetComponent<DoorOpen> ().closeDoor ();
			}
			if (door3 != null) {
				door3.GetComponent<DoorOpen> ().closeDoor ();
			}
		}
		if (counter >= -150 && counter < -5) {
			gameObject.GetComponent<Rigidbody> ().AddTorque (-transform.up * Time.deltaTime * 10f);
		} else if (counter >= -5 && counter < 0) {
			GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
		} else if (counter > 5 && counter <= 150) {
			gameObject.GetComponent<Rigidbody> ().AddTorque (transform.up * Time.deltaTime * 10f);
		} else if (counter > 150 && counter < 295) {
			gameObject.GetComponent<Rigidbody> ().AddTorque (-transform.up * Time.deltaTime * 10f);
		} else if (counter >= 295 && counter <= 305) {
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		} else if (counter > 305 && counter <= 450) {
			gameObject.GetComponent<Rigidbody> ().AddTorque (-transform.up * Time.deltaTime * 10f);
		} else if (counter > 450 && counter < 595) {
			gameObject.GetComponent<Rigidbody> ().AddTorque (transform.up * Time.deltaTime * 10f);
		} else if (counter >= 595 && counter <= 605) {
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
		else {
			counter = 0;
		}
	}
}
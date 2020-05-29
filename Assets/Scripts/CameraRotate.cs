using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour {
	public Transform ship;
	public Transform arwing;
	public GameObject boost;
	public GameObject boss;
	public GameObject aimAt;
	public GameObject shoot;
	public GameObject hud;
	public GameObject reticles;
	public bool rotating = false;
	float count = 0;

	void Start () {

		aimAt.GetComponent<ReticleMove> ().enabled = false;
		ship.GetComponent<ArwingAimAtReticle> ().enabled = false;
		boost.GetComponent<Boost> ().enabled = false;
		gameObject.GetComponent<CameraFollow> ().enabled = false;
		shoot.GetComponent<Shoot> ().enabled = false;
		hud.SetActive (false);
		transform.position = new Vector3 (0, 0, transform.position.z);
		ship.transform.position = new Vector3 (transform.position.x, transform.position.y, ship.transform.position.z);
		aimAt.transform.position = new Vector3 (transform.position.x, transform.position.y, aimAt.transform.position.z);
		arwing.transform.eulerAngles = new Vector3 (0, 180, 0);
		reticles.SetActive (false);
		//rotate.enabled = true;
	}
	// Update is called once per frame
	void Update () {
		if (!rotating && count < 360) {
			transform.RotateAround (ship.position, Vector3.up, 60 * Time.deltaTime);
			transform.LookAt (ship);
			count += 60 * Time.deltaTime;
		} else {
			aimAt.GetComponent<ReticleMove> ().enabled = true;
			reticles.SetActive (true);
			boost.GetComponent<Boost> ().enabled = true;
			shoot.GetComponent<Shoot> ().enabled = true;
			ship.GetComponent<ArwingAimAtReticle> ().enabled = true;
			hud.SetActive (true);
			boss.SetActive (true);
			gameObject.GetComponent<CameraFollow> ().enabled = true;
		}
		if (count == 360) {
			rotating = true;
		}
	}
}

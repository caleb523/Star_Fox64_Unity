using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrelRoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public float rotationCoefficient = 3;
	public Transform pivot;
	public Transform aimAt;
	public float rotationSpeed;
	int counter;
	// Update is called once per frame
	void Update () {
		float step = rotationCoefficient * Time.deltaTime;
		if (Input.GetAxis ("RotateRight") > 0) {
			//Vector3 newDir = Vector3.RotateTowards (transform.forward, new Vector3 (transform.position.x, transform.position.y, -1 * Input.GetAxis ("RotateRight")), step, 1.0F);
			//transform.rotation = Quaternion.LookRotation(newDir);
			//transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, -90 * Input.GetAxis ("RotateRight"));
		} else if (Input.GetAxis ("RotateLeft") > 0) {
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.y, 90 * Input.GetAxis ("RotateLeft"));
		} else {
			transform.localEulerAngles = new Vector3 (0, 180, rotationCoefficient * (aimAt.position.x - pivot.position.x));
		}
	}
}

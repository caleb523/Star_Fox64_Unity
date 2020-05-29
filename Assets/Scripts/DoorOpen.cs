using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {
	public float velocity;
	public float force;
	// Use this for initialization
	public void openDoor () {
		HingeJoint hinge = GetComponent<HingeJoint> ();
		JointMotor motor = hinge.motor;
		motor.force = force;
		motor.targetVelocity = velocity;
		hinge.motor = motor;
		hinge.useMotor = true;
	}

	public void closeDoor () {
		HingeJoint hinge = GetComponent<HingeJoint> ();
		JointMotor motor = hinge.motor;
		motor.force = force;
		motor.targetVelocity = -velocity;
		hinge.motor = motor;
		hinge.useMotor = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}

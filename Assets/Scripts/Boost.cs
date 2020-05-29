using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {
	bool isBoosting;
	public AudioSource audioCenter;
	public AudioClip boostSound;
	// Use this for initialization
	void Start () {
		Manager.instance.boost = 0;
		isBoosting = false;
	}
	// Update is called once per frame
	void Update () {
		if ((Input.GetButton ("Boost")) && Manager.instance.boost >= Manager.instance.maxBoost && Time.deltaTime !=0) {
			audioCenter.PlayOneShot(boostSound);
			isBoosting = true;
			Manager.instance.worldSpeed *= 2;
		} else if ((Input.GetButton ("Slow")) && Manager.instance.boost >= Manager.instance.maxBoost && Time.deltaTime !=0) {
			audioCenter.PlayOneShot(boostSound);
			isBoosting = true;
			Manager.instance.worldSpeed /= 2;
		}
		if (isBoosting && Manager.instance.boost > 0 && Time.deltaTime != 0) {
			Manager.instance.boost -= 2 * Time.deltaTime * 60;
			gameObject.GetComponent<BoostUpdate>().BarUpdate();
		} else if (Time.deltaTime != 0) {
			if (Manager.instance.boost < Manager.instance.maxBoost){
				Manager.instance.boost++;
				gameObject.GetComponent<BoostUpdate>().BarUpdate();
			}
			Manager.instance.worldSpeed = Manager.instance.worldSpeedMin;
			isBoosting = false;
		}
	}
}

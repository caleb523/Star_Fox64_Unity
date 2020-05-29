using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStartScreen : MonoBehaviour {
	public AudioClip goodLuck;
	public GameObject introScreen;
	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		Manager.instance.audioCenter.PlayOneShot (goodLuck);
	}
	public int count = 0;
	// Update is called once per frame
	void Update () {
		if (count < 90) {
			count++;
		} else {
			gameObject.SetActive (false);
			introScreen.SetActive (true);
			Time.timeScale = 1;

		}
	}
}

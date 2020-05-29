using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreen : MonoBehaviour {

	public GameObject hud;
	// Use this for initialization
	void Start () {
		StartCoroutine (waitIntro ());
		Manager.instance.musicCenter.Play ();
	}
	
	// Update is called once per frame
	IEnumerator waitIntro()
	{
		yield return new WaitForSeconds(5f);
		gameObject.SetActive (false);
		hud.GetComponent<PauseScreen> ().enabled = true;
	}
}

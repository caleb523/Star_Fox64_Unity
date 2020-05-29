using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

	public GameObject pauseScreen;
	public AudioClip startSound;
	public AudioClip menuMove;
	public AudioClip menuSelect;
	bool isPaused = false;
	public bool isOnContinue = true;
	public Text continueText;
	public Text restartText;
	float counter = 0;
	void Update () {
		if (Input.GetButtonDown (buttonName: "Pause") && !isPaused && counter > 15) {
			pauseScreen.SetActive (true);
			Time.timeScale = 0;
			isPaused = true;
			Manager.instance.musicCenter.Pause ();
			Manager.instance.audioCenter.PlayOneShot (startSound);
			isOnContinue = true;
		} else if (Input.GetButtonDown (buttonName: "Pause") && isPaused && counter > 15) {
			Time.timeScale = 1;
			isPaused = false;
			Manager.instance.musicCenter.Play ();
			pauseScreen.SetActive (false);
		} else if (isPaused) {
			if ((Input.GetAxis ("Vertical") > 0.5) && isOnContinue && counter > 15) {
				isOnContinue = false;
				Manager.instance.audioCenter.PlayOneShot (menuMove);
				restartText.color = new Color (149f/255, 90f/255, 92f/255);
				continueText.color = new Color (64f/255, 64f/255, 64f/255);
				counter = 0;
			} else if ((Input.GetAxis ("Vertical") < -0.5) && !isOnContinue && counter > 15) {
				isOnContinue = true;
				Manager.instance.audioCenter.PlayOneShot (menuMove);
				restartText.color = new Color (64f/255, 64f/255, 64f/255);
				continueText.color = new Color (149f/255, 90f/255, 92f/255);
				counter = 0;
			} else if (Input.GetButtonDown ("Shoot")) {
				if (isOnContinue) {
					pauseScreen.SetActive (false);
					isPaused = false;
					Manager.instance.audioCenter.PlayOneShot (startSound);
					Manager.instance.musicCenter.Play ();
					Time.timeScale = 1;
				} else { //restart scene;
					Manager.instance.audioCenter.PlayOneShot (menuSelect);
					Manager.instance.lives --;
				//	SceneManager.LoadScene(SceneManager.GetActiveScene) ;
				}
			}

		}
		if (counter <= 15) {
			counter++;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostUpdate : MonoBehaviour {
	Image boostBar;
	// Use this for initialization
	void Start()
	{
		boostBar = GetComponent<Image>();
	}
	public void BarUpdate () {
		boostBar.fillAmount = (Manager.instance.boost / Manager.instance.maxBoost);
	}
}

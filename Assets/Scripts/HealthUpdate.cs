using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUpdate : MonoBehaviour {
    Image healthBar;
	// Use this for initialization
    void Start()
    {
        healthBar = GetComponent<Image>();
    }
public void BarUpdate () {
		healthBar.fillAmount = (Manager.instance.health / Manager.instance.maxHealth);
	}
}

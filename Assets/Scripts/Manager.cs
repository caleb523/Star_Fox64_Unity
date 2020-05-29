using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager :MonoBehaviour {
	
	public Transform player;
    public static Manager instance = null;

    public float worldSpeed;
	public float worldSpeedMin;
    public int upgradeLevel = 1;
    public float health = 10;
    public float maxHealth = 15;
    public int lives;
    public int score = 0;
    public int rings = 0;
	public float boost;
	public float maxBoost;
    public int bombs;
    public int xBounds = 16;
    public GameObject Hit;
	public GameObject explosion1;
	public GameObject chargeTarget = null;
	public AudioSource audioCenter;
	public AudioSource musicCenter;
	public AudioClip levelMusic;
	public AudioClip bossA;
	public AudioClip noDamage;
	public AudioClip damage;
	public bool isRolling;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
}

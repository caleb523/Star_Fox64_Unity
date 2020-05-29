using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float shotSpeed;
    public GameObject bulletPrefab;
    public GameObject blueLaser;
    public GameObject chargeShot;
	GameObject chargeBullet;
	public GameObject camera;
    public Transform bulletSpawnM;
    public Transform bulletSpawnL;
    public Transform bulletSpawnR;
    public float chargeTime = 5;
    public float fireRate = 10;
    public float timer = 0;
    public float shotTimer = 0;
	public float shotTime = 2.0f;
	float lockTimer = 0;
	public Transform lockIcon;

    public AudioClip singleLaser;
    public AudioClip doubleLaser;
    public AudioClip hyperLaser;
    public AudioClip chargeHold;
    public AudioClip chargeAudio;
	public AudioClip chargeLock;
    public AudioSource audioCenter;

    public SpriteRenderer frontReticleRender;
    public SpriteRenderer backReticleRender;
    public GameObject frontReticle;
    public GameObject backReticle;
    private int red = 0; private int green = 255;
    bool charging = false;
	bool locked = false;

    void Start()
    {
        audioCenter = gameObject.AddComponent<AudioSource>();
        frontReticleRender = frontReticle.GetComponent<SpriteRenderer>();
        backReticleRender = backReticle.GetComponent<SpriteRenderer>();
    }

    void FireSingle()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawnM.position,
            bulletSpawnM.rotation);
       
		bullet.GetComponentInChildren<Renderer> ().material.SetColor("_Color", Color.green);
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shotSpeed;

        Destroy(bullet, 2.0f);
    }

    void FireDouble()
    {
        var bulletL = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawnL.position,
            bulletSpawnL.rotation);

        var bulletR = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawnR.position,
            bulletSpawnR.rotation);
		bulletL.GetComponentInChildren<Renderer> ().material.SetColor("_Color", Color.green);
		bulletR.GetComponentInChildren<Renderer> ().material.SetColor("_Color", Color.green);
		bulletL.GetComponent<Rigidbody>().velocity = bulletL.transform.forward * shotSpeed;
		bulletR.GetComponent<Rigidbody>().velocity = bulletR.transform.forward * shotSpeed;

        Destroy(bulletL, 2.0f);
        Destroy(bulletR, 2.0f);

    }

    void FireDoubleBlue()
    {
        var bulletL = (GameObject)Instantiate(
			bulletPrefab,
            bulletSpawnL.position,
            bulletSpawnL.rotation);

        var bulletR = (GameObject)Instantiate(
			bulletPrefab,
            bulletSpawnR.position,
            bulletSpawnR.rotation);

		bulletL.GetComponentInChildren<Renderer> ().material.SetColor("_Color", Color.cyan);
		bulletR.GetComponentInChildren<Renderer> ().material.SetColor("_Color", Color.cyan);
		bulletL.GetComponent<Rigidbody>().velocity = bulletL.transform.forward * shotSpeed;
		bulletR.GetComponent<Rigidbody>().velocity = bulletR.transform.forward * shotSpeed;
		bulletL.tag = "Laser2";
		bulletR.tag = "Laser2";

        Destroy(bulletL, 2.0f);
        Destroy(bulletR, 2.0f);

    }

    void ChargeShot()
    {
        audioCenter.PlayOneShot(chargeAudio);
        // Create the Bullet from the Bullet Prefab
        var bulletCharge = (GameObject)Instantiate(
            chargeShot,
            bulletSpawnM.position,
            bulletSpawnM.rotation);
		chargeBullet = bulletCharge;

		if (locked && Manager.instance.chargeTarget != null && lockTimer > 10) {
			bulletCharge.GetComponent<Rigidbody> ().AddForce ((backReticle.transform.position - frontReticle.transform.position).normalized * 1000 * Time.smoothDeltaTime);
			for(float i = 0; i < shotTime * 60; i += shotTime * Time.deltaTime * 60) {
				bulletCharge.GetComponent<Rigidbody> ().AddForce ((Manager.instance.chargeTarget.transform.position - transform.position).normalized * 5000 * Time.smoothDeltaTime);
			}
		} else {
			bulletCharge.GetComponent<Rigidbody>().velocity = bulletCharge.transform.forward * shotSpeed;
		}
        
        Destroy(bulletCharge, 3.0f);
    }
    
    void Update () {
		shotTimer += Time.deltaTime * 30;
        if ((Input.GetButtonDown(buttonName: "Shoot") && (shotTimer > fireRate)))
        {
            shotTimer = 0;
            if (Manager.instance.upgradeLevel == 1)
                {
                audioCenter.PlayOneShot(singleLaser);
                FireSingle();
                }
            if (Manager.instance.upgradeLevel == 2)
                {
                audioCenter.PlayOneShot(doubleLaser);
                FireDouble();
                }
            if (Manager.instance.upgradeLevel == 3)
                {
                audioCenter.PlayOneShot(hyperLaser);
                FireDoubleBlue();
                }
               
        }
		else if (Input.GetButton(buttonName: "Shoot") && chargeBullet == null)
        {
			if (!locked) {
				RaycastHit hit;
				if (Physics.Raycast (camera.transform.position, (backReticle.transform.position - camera.transform.position), out hit, 300) && (hit.transform.tag == "ChargeTarget" || hit.transform.tag == "Enemy") && !locked && timer > chargeTime / 2) {
					audioCenter.PlayOneShot (chargeLock);
					Manager.instance.chargeTarget = hit.collider.gameObject;
					locked = true;
				}
			}
			if (locked) {
				lockTimer += Time.deltaTime * 60;
				if (lockTimer > 10) {
					lockIcon.gameObject.SetActive (true);
					lockIcon.position = Manager.instance.chargeTarget.transform.position;
				}
			}
			if (timer > 5)
            {
                if ((red < 256) && (green > 0))
                {
                    red += 20; green -= 20;
                }
            }

            backReticleRender.color = new Color(red, green, 0);
            frontReticleRender.color = new Color(red - 128, green + 128, 0);
			timer += Time.deltaTime * 60;
            if ((!charging) && timer > 10)
            {
                audioCenter.PlayOneShot(chargeHold);
                charging = true;
            }
        }
		else if (Input.GetButtonUp(buttonName: "Shoot") && chargeBullet == null)
        {
			if (timer >= chargeTime) {
				ChargeShot();
			}
			lockIcon.gameObject.SetActive (false);
            timer = 0;
            red = 0; green = 255;
            frontReticleRender.color = new Color(red, green, 0);
            backReticleRender.color = new Color(red, green, 0);
            charging = false;
			locked = false;
			lockTimer = 0;
        }
    }
}
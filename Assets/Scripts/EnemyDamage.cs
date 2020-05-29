using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {
    public int health = 5;
	public int scoreValue;
	int flashCounter = 0;
	public Component[] materials;
	void Start() {
		materials = GetComponentsInChildren<Renderer> ();
	}
    void OnTriggerEnter(Collider other)
    {
		
		flashCounter = 0;
        if (other.gameObject.CompareTag("Laser1"))
        {
            other.gameObject.SetActive(false);
            health--;
			Manager.instance.audioCenter.PlayOneShot (Manager.instance.damage);
			foreach (Renderer Standard in materials) {
				Standard.material.color = Color.red;
			}

        }
        if (other.gameObject.CompareTag("Laser2"))
        {
            other.gameObject.SetActive(false);
            health = health - 2;
			Manager.instance.audioCenter.PlayOneShot (Manager.instance.damage);
			foreach (Renderer Standard in materials) {
				Standard.material.color = Color.red;
			}
        }
        if (other.gameObject.CompareTag("ChargeShot"))
        {
            other.gameObject.SetActive(false);
            health = health - 5;
			Manager.instance.audioCenter.PlayOneShot (Manager.instance.damage);
			foreach (Renderer Standard in materials) {
				Standard.material.color = Color.red;
			}
        }
    }
    void Update()
    {
		flashCounter++;
		if (flashCounter > 5) {
			foreach (Renderer Standard in materials) {
				Standard.material.color = Color.white;
			}
		}
        if (health <= 0)
        {
            Destroy(gameObject);
			GameObject explosion;
			GameObject clone;
            clone = GameObject.Instantiate(Manager.instance.Hit, transform.position + new Vector3(0,3,0), Quaternion.identity) as GameObject;
            clone.GetComponent<Rigidbody>().velocity = clone.transform.up * 2;

			explosion = GameObject.Instantiate(Manager.instance.explosion1, transform.position + new Vector3(0,3,0), Quaternion.identity) as GameObject;
			explosion.transform.localScale = new Vector3(5,5,5);

            // Destroy the bullet after 2 seconds
            Destroy(clone, 2.0f);
			Destroy(explosion, .25f);
			Manager.instance.score += scoreValue;
        }
    }
}

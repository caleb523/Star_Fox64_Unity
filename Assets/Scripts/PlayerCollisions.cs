using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {

    public AudioClip upgradeAudio;
    public AudioClip bombPickupAudio;
    public AudioSource audioCenter;
    public GameObject healthObject;
    public GameObject bombObject;
	public GameObject shader;
	float flashCounter = 0;
	void Start() {
        audioCenter = gameObject.AddComponent<AudioSource>();
    }
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Upgrade"))
        {
            audioCenter.PlayOneShot(upgradeAudio, 1.0F);
			Destroy(other.gameObject);

            if (Manager.instance.upgradeLevel < 3)
            {
                Manager.instance.upgradeLevel = Manager.instance.upgradeLevel + 1;
            }
        } else if (other.gameObject.CompareTag("Bomb"))
        {
            audioCenter.PlayOneShot(bombPickupAudio, 1.0F);
            Destroy(other.gameObject);

            if (Manager.instance.bombs < 3)
            {
                Manager.instance.bombs = Manager.instance.bombs + 1;
                bombObject.GetComponent<BombDisplay>().Start();
            }
        }
        else if (other.gameObject.CompareTag("EnemyShot1"))
        {
			flashCounter = 0;
			shader.GetComponent<Renderer> ().material.color = Color.red;
			Destroy(other.gameObject);
            Manager.instance.health--;
            healthObject.GetComponent<HealthUpdate>().BarUpdate();
        }
    }
    // Update is called once per frame
    void Update () {
		flashCounter += 60 * Time.deltaTime;
		if (flashCounter > 5) {
			shader.GetComponent<Renderer> ().material.color = Color.white;
		}
		if (Manager.instance.health <= 0)
        {
            transform.gameObject.SetActive(false);
        }
	}
}

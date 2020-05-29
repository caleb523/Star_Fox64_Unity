using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour {
    public Transform arwing;
    int timer = 0;
    int moveCounter = 0;
    public float shotSpeed;
    public GameObject bulletPrefab;
    public Transform bulletSpawnTank;
    public int moveTime = 60;
    public float moveSpeed = 1;
    public float shotTime = 45f;
    // Update is called once per frame
    void FireTank()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawnTank.position,
            bulletSpawnTank.rotation);


        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * shotSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 4.0f);
    }

    void Update()
    {
		float dist = Vector3.Distance(arwing.position, transform.position);
		if ((moveCounter < moveTime) && (dist < 200))
        {
            transform.Translate(new Vector3(0, 0, moveSpeed/10));
            moveCounter++;
        }
        if ((dist < 200) && (transform.position.z > arwing.position.z + 5) && (moveCounter >= moveTime))
        {
            transform.LookAt(new Vector3(arwing.position.x, transform.position.y, arwing.position.z));
            bulletSpawnTank.LookAt(arwing);
            if (timer > shotTime)
            {
                FireTank();
                timer = 0;
            }
        }
        timer++;
    }
}

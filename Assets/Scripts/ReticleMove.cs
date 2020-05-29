using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class ReticleMove : MonoBehaviour
{
    public float reticleSpeed = 3.0F;
	public float rotationCoefficient = 3;
    public Transform ship;
	public Transform arwing;
    public float shipSpeed;
	void Start() {
	}
	void Update()
    {
        CharacterController charControl = GetComponent<CharacterController>();
        if ((Input.GetAxis("Vertical") > 0) && transform.position.y > -11)
			charControl.Move(60 * Time.deltaTime * new Vector3(0, -reticleSpeed * Input.GetAxis("Vertical"), 0));
        else if ((Input.GetAxis("Vertical") < 0) && transform.position.y < 10)
			charControl.Move(60 * Time.deltaTime * new Vector3(0, -reticleSpeed * Input.GetAxis("Vertical"), 0));
        if ((Input.GetAxis("Horizontal") < 0) && transform.position.x > - Manager.instance.xBounds)
			charControl.Move(60 * Time.deltaTime * new Vector3(reticleSpeed * Input.GetAxis("Horizontal"), 0, 0));
        else if ((Input.GetAxis("Horizontal") > 0) && transform.position.x < Manager.instance.xBounds)
			charControl.Move(60 * Time.deltaTime * new Vector3(reticleSpeed * Input.GetAxis("Horizontal"), 0, 0));
        if ((Input.GetAxis("Vertical") != 0) && (Input.GetAxis("Horizontal") != 0))
        {
			//arwing.localEulerAngles = new Vector3 (0, 180, rotationCoefficient * (transform.position.x - ship.position.x));
			float step = Time.deltaTime * shipSpeed;
            var pos = arwing.position;
            var pos2 = transform.position;
            if (((pos2.x >= - Manager.instance.xBounds) && (pos2.x <= Manager.instance.xBounds)) || ((pos.x >= - Manager.instance.xBounds + 2) && (pos.x <= Manager.instance.xBounds - 2)))
            {
				ship.position = Vector3.MoveTowards(ship.position,new Vector3(transform.position.x, ship.position.y, ship.position.z), 2 * step);
            }
            if (((pos2.y >= -9) && (pos2.y <= 9)) || ((pos.y >= -9) && (pos.y <= 9)))
            {
				ship.position = Vector3.MoveTowards(ship.position,new Vector3(ship.position.x, transform.position.y, ship.position.z), step);
            }
        }
		else
        {
			//arwing.localEulerAngles = new Vector3 (0, 180, transform.position.x - ship.position.x);
            float step = Time.deltaTime * shipSpeed;
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(arwing.position.x, arwing.position.y, transform.position.z), step * 2);

        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreventRotate : MonoBehaviour {
    // Use this for initialization
    public Transform ship;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(transform.position.x, transform.position.y, ship.position.z));
    }
}

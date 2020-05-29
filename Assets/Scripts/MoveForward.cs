using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Manager.instance.worldSpeed);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadBehind : MonoBehaviour {
	void Update () {
		if ((Manager.instance.player.position.z - transform.position.z) > 10)
        {
            Destroy(gameObject);
            Resources.UnloadUnusedAssets();
        }
	}
}
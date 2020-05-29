using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDisplay : MonoBehaviour {
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;
    public void Start()
    {
        bombUIUpdate(bomb1, bomb2, bomb3);
    }
    
	public void bombUIUpdate(GameObject bomb1, GameObject bomb2, GameObject bomb3) { 
        switch (Manager.instance.bombs) {
            case 0:
                bomb1.gameObject.SetActive(false);
                bomb2.gameObject.SetActive(false);
                bomb3.gameObject.SetActive(false);
                break;
            case 1:
                bomb1.gameObject.SetActive(true);
                bomb2.gameObject.SetActive(false);
                bomb3.gameObject.SetActive(false);
                break;
            case 2:
                bomb1.gameObject.SetActive(true);
                bomb2.gameObject.SetActive(true);
                bomb3.gameObject.SetActive(false);
                break;
            case 3:
                bomb1.gameObject.SetActive(true);
                bomb2.gameObject.SetActive(true);
                bomb3.gameObject.SetActive(true);
                break;
        }
    }
}

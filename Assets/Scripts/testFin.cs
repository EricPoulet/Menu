using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testFin : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.transform.tag == "Portail")
        {
            if(Application.loadedLevelName == "Lvl1")
                Application.LoadLevel("Lvl2");
            else if (Application.loadedLevelName == "Lvl2")
                Application.LoadLevel("Lvl3");
            else if (Application.loadedLevelName == "Lvl3")
                Application.LoadLevel("Menu");

        }
    }
}

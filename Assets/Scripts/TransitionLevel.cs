using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionLevel : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		 
	}﻿

	public void lvl1() {
		Application.LoadLevel("Lvl1");
		}

    public void lvl2()
    {
        Application.LoadLevel("Lvl2");
    }

    public void lvl3()
    {
        Application.LoadLevel("Lvl3");
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backwards : MonoBehaviour {
	public float speed=0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2(Time.time * speed, 0);
	}
}

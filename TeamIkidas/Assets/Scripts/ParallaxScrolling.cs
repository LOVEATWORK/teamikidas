﻿using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {

	public Vector2 speed = new Vector2(2,2);
	public Vector2 direction = new Vector2(-1,0);
	public bool isLinkedToCamera = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 movement = new Vector3 (
			speed.x * direction.x,
			speed.y * direction.y,
			0);

		movement *= Time.deltaTime;
		transform.Translate (movement);

		// Move the camera
		if (isLinkedToCamera) {
				
			Camera.main.transform.Translate(movement);

		}

	}
}
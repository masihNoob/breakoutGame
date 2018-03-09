﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour {
	public GameObject brickParticles;
	private void OnCollisionEnter(Collision other) {
		Instantiate(brickParticles, transform.position,Quaternion.identity);
		GameHandler.instance.DestroyBrick();
		Destroy(gameObject);
	}
}

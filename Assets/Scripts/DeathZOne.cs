using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZOne : MonoBehaviour {
	private void OnTriggerEnter(Collider other) {
		GameHandler.instance.LoseLife();
	}
}

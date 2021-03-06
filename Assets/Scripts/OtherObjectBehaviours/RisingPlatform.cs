﻿using UnityEngine;
using System.Collections;

public class RisingPlatform : MonoBehaviour {

	public float riseAmount;
	public float riseSpeed;
	float initialHeight;
	private bool audioPlaying = false;
	// Use this for initialization
	void Start () {
		initialHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(!audioPlaying && transform.rigidbody.velocity != new Vector3(0,0,0)){
			audio.Play();
			audioPlaying = true;
		}
		else if(!audioPlaying && transform.rigidbody.velocity == new Vector3(0,0,0)){
			audio.Stop();
			audioPlaying = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag != "Rope"){
			Debug.Log ("Collided");

			StartCoroutine("Rise");
		}
	}

	IEnumerator Rise() {

		Debug.Log ("Rising");

		transform.rigidbody.velocity = Vector3.up * riseSpeed;

		while (true) {
			if (initialHeight + riseAmount <= transform.position.y) {
				transform.rigidbody.velocity = Vector3.zero;
				audio.Stop();
				break;
			}
				yield return 0;
		}
	}
}

﻿using UnityEngine;
using System.Collections;

public class Level6Platforms : MonoBehaviour {

	GameObject GameManager;
	private Vector3 explosion;
	private float time = 0.0f;
	private bool isRigid = false;

	// Use this for initialization
	void Start () {

		this.explosion = new Vector3(Random.Range (-25.0f,25.0f), 0 , Random.Range (-25.0f, 25.0f));
		GameManager = GameObject.FindGameObjectWithTag("GameController");
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isRigid == true){
			time += Time.deltaTime;
			if(time > 3.5f){
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		//Allows only the player to collide with cubes. Adjust if you want other collisions.
		if(other.tag == "Player"){
		GameManager.GetComponent<Level6>().PlatformTrigger(this.transform.position);
		}
	}

	public void Fall() {
		Debug.Log ("Woo!");
		if(isRigid == false){
		this.audio.Play();
		this.gameObject.AddComponent<Rigidbody>();
		this.rigidbody.useGravity = true;
		this.gameObject.rigidbody.AddTorque(explosion);
		this.isRigid = true;
		}
	}
}

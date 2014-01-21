using UnityEngine;
using System.Collections;

public class SetPiece : MonoBehaviour {

	bool waitForPlayer;
	bool hasWaited;

	public GameObject Fire;
	public GameObject Rock;
	public GameObject floor;

	public float timeBetweenFire = 3;
	public bool isRockEvent;
	public float timer;
	// Use this for initialization
	void Start () {

		hasWaited = false;
		waitForPlayer = true;
		isRockEvent = false;

		timer = 30;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= 59.5 && !hasWaited) {
			Debug.Log("Waiting");
			waitForPlayer = true;
			hasWaited = true;
			rigidbody.velocity = Vector3.zero;
		}
		if (transform.position.y >= 95) {
			//rigidbody.useGravity = true;
			rigidbody.velocity = Vector3.zero;
			//rigidbody.AddForce(Vector3.down * 50);
			//rigidbody.freezeRotation = false;
			Destroy (this.GetComponent<SetPiece>());
		}

		if (isRockEvent) {
			timer -= Time.deltaTime;
			rigidbody.velocity = Vector3.up;
		}

		if (timer <= 0)
			isRockEvent = false;

	}

	void OnTriggerEnter(Collider other) {
		if (waitForPlayer && other.tag == "Player") {
			waitForPlayer = false;
			rigidbody.AddForce(Vector3.up * 10000);
			if (transform.position.y < 5) {
				StartCoroutine("FireEvent");
				Destroy (floor.gameObject);
			}
			else {
				//isRockEvent = true;
				//StartCoroutine("RockEvent");
			}
		}
	}
	void OnTriggerExit(Collider other) {
		if(other.tag == "Player"){
			waitForPlayer = false;
			hasWaited = true;
			isRockEvent = true;
			//StartCoroutine("RockEvent");
			Debug.Log("Player Exited");
			rigidbody.AddForce(Vector3.up * 10000);

		}
	}

	IEnumerator FireEvent() {
		yield return new WaitForSeconds(3.0f);
		Instantiate(Fire, new Vector3(4, transform.position.y + 2, 4), transform.rotation);
		yield return new WaitForSeconds(timeBetweenFire);
		Instantiate(Fire, new Vector3(-4, transform.position.y + 2, 0), transform.rotation);
		yield return new WaitForSeconds(timeBetweenFire);
		Instantiate(Fire, new Vector3(4, transform.position.y + 2, 0), transform.rotation);
		yield return new WaitForSeconds(timeBetweenFire);
		Instantiate(Fire, new Vector3(-4, transform.position.y + 2, -4), transform.rotation);
		yield return new WaitForSeconds(timeBetweenFire);
		Instantiate(Fire, new Vector3(4, transform.position.y + 2, -4), transform.rotation);
		yield return new WaitForSeconds(timeBetweenFire);
		Instantiate(Fire, new Vector3(-4, transform.position.y + 2, 4), transform.rotation);
		yield return new WaitForSeconds(timeBetweenFire);
		Instantiate(Fire, new Vector3(0, transform.position.y + 2, -4), transform.rotation);
		yield return new WaitForSeconds(timeBetweenFire);
		//Instantiate(Fire, new Vector3(0, transform.position.y + 2, 0), transform.rotation);
		//yield return new WaitForSeconds(timeBetweenFire);
		//Instantiate(Fire, new Vector3(0, transform.position.y + 2, 4), transform.rotation);
		//yield return new WaitForSeconds(timeBetweenFire);
	}
	IEnumerator RockEvent() {

		while(isRockEvent) {
			yield return new WaitForSeconds(Random.value * 2  + 1);
			Instantiate(Rock, new Vector3(Random.value * 4, transform.position.y + 10, Random.value * 4), transform.rotation);
		}
	}
}

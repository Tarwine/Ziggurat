using UnityEngine;
using System.Collections;

public class SparkleShot : MonoBehaviour {
	public GameObject explosion;
	public GameObject platformArea;
	public GameObject explosionSpawn;
	public GameObject areaSpawn;
	private bool hasFired = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if(!hasFired){
			Instantiate(explosion, explosionSpawn.transform.position, explosionSpawn.transform.rotation);
			Instantiate(platformArea, areaSpawn.transform.position, areaSpawn.transform.rotation);
			Destroy(GameObject.Find("gemOBJ"));
			audio.Play();
			Debug.Log("Took the Cat");
			hasFired = true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class AmbientPersist : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

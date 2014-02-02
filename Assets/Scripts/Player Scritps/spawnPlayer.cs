using UnityEngine;
using System.Collections;

public class spawnPlayer : MonoBehaviour {
	public Object playerPrefab;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("Player") == null){
			Instantiate(playerPrefab);
			GameObject.FindWithTag("Player").transform.position = this.transform.position;
		}
		else if(GameObject.FindGameObjectWithTag("Player") != null && PlayerPrefs.GetString("isDead") == "false"){
			GameObject.FindWithTag("Player").transform.position = this.transform.position;
			PlayerPrefs.SetString("isDead","true");
			Debug.Log("Player Switching Levels");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

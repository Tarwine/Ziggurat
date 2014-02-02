using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {
	

	// Use this for initialization
	void Start () {

/*		if(PlayerPrefs.GetString("isDead") == "true"){
			Debug.Log ("Player has died, respawn at checkpoint");
			GameObject.FindWithTag("Player").transform.position = new Vector3(PlayerPrefs.GetFloat ("PlayerX"), PlayerPrefs.GetFloat ("PlayerY"), PlayerPrefs.GetFloat ("PlayerZ"));

		}
		else{
			Debug.Log ("Player hasn't died, load level from spawn");
			GameObject.FindWithTag("Player").transform.position = GameObject.Find("spawn").transform.position;
		}*/

		if(Application.isPlaying){
			Screen.showCursor = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	if(Input.GetKeyDown (KeyCode.Escape) ){
			Application.Quit();

		}
	}
	public void respawnPlayer(){
		Debug.Log("Player respawned at checkpoint");
		GameObject.FindWithTag("Player").transform.position = new Vector3(PlayerPrefs.GetFloat ("PlayerX"), PlayerPrefs.GetFloat ("PlayerY"), PlayerPrefs.GetFloat ("PlayerZ"));
	}
	void OnApplicationQuit(){
		Debug.Log("Application Quit");
		PlayerPrefs.SetString ("isDead", "false");
		PlayerPrefs.SetFloat ("PlayerX", GameObject.Find("spawn").transform.position.x);
		PlayerPrefs.SetFloat ("PlayerY", GameObject.Find("spawn").transform.position.y);
		PlayerPrefs.SetFloat ("PlayerZ", GameObject.Find("spawn").transform.position.z);
	}

}
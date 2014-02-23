using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public Texture pauseMenuImage;
	private GameObject pauseMenu;
	private bool isPaused;
	private Camera pauseCamera;

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

		if(Application.isPlaying && !Application.isWebPlayer){
			Screen.showCursor = false;
		}
		else if(Application.isPlaying && Application.isWebPlayer){
			Screen.showCursor = false;
			Screen.lockCursor = true;
		}

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) && Application.isPlaying && !Application.isWebPlayer){
			Application.Quit();
		}
		else if(Input.GetKeyDown (KeyCode.Escape) && Application.isPlaying && Application.isWebPlayer && !Screen.showCursor){
			Screen.showCursor = true;
			Screen.lockCursor = false;

			Time.timeScale = 0;
			AudioListener.pause = true;
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.GetComponent<MouseLookJoy>().enabled = false;
			player.GetComponentInChildren<HeadBobber>().enabled = false;
			
			GameObject camera = GameObject.FindWithTag("MainCamera");
			camera.GetComponent<MouseLookJoy>().enabled = false;

			isPaused = true;
		}
		else if(Input.GetMouseButtonDown(0) && Application.isPlaying && Application.isWebPlayer && Screen.showCursor){
			Screen.showCursor = false;
			Screen.lockCursor = true;
			Time.timeScale = 1;
			AudioListener.pause = false;
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			player.GetComponent<MouseLookJoy>().enabled = true;
			player.GetComponentInChildren<HeadBobber>().enabled = true;


			GameObject camera = GameObject.FindWithTag("MainCamera");
			camera.SetActive(true);
			camera.GetComponent<MouseLookJoy>().enabled = true;

			isPaused = false;
		}
	}
	void OnGUI(){
		if(isPaused){
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pauseMenuImage, ScaleMode.StretchToFill, true, 1.0f);
		}
	}
	public void respawnPlayer(){
		Debug.Log("Player respawned at checkpoint");
		SendMessage("setClearNow");
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
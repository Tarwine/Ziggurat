using UnityEngine;
using System.Collections;

public class playerInteract : MonoBehaviour {
	public GameObject grabbedRope;
	public GameObject closestRope;
	public string usingAxis;
	private bool ropeRange;
	private bool holding;
	public bool isGrounded = true;
	private float timez;
	private float deadTime;
	public bool isdead;
	public AudioClip deathSound;
	private bool deathSoundPlayed = false;
	private bool holdingJoy = false;

	// Use this for initialization
	void Start () {
		ropeRange = false;
		holding = false;
		isdead = false;
		timez = 0;
		DontDestroyOnLoad(transform.gameObject);
		//PlayerPrefs.SetString("isDead", "false");
	}
	public void reset(){
		ropeRange = false;
		holding = false;
		isdead = false;
		deathSoundPlayed = false;
		deadTime = 0 ;
		timez = 0;
		//PlayerPrefs.SetString("isDead", "false");
	}

	public bool deadReturn(){

		return isdead;
	}

	void setGrounding(bool ground){

		isGrounded = ground;
	}

	// Update is called once per frame
	void Update () {

		//The following lines of code kill the player if he is in the air too long
		//********************
		SendMessage("getGrounded");

		if(!isGrounded && !holding){
			timez += Time.deltaTime;
		}
		if(isGrounded || holding){
			if(timez > 100.5f && !holding){
				isdead = true;
				if(!deathSoundPlayed){
					audio.PlayOneShot(deathSound);
					deathSoundPlayed = true;
				}
				PlayerPrefs.SetString("isDead", "true");
			}else{
				timez = 0;
			}
		}
		if(isdead){
			deadTime += Time.deltaTime;
			if(deadTime > 1.5f){
				Application.LoadLevel(Application.loadedLevel);
				reset();
				SendMessage("respawnPlayer");
			}
		}

		//******************************


		if(holding == true && usingAxis == "x"){
			this.transform.position = grabbedRope.transform.position + (grabbedRope.transform.forward + new Vector3(0.0f, -1.5f, 0.0f));
		}
		if(holding == true && usingAxis == "z"){
			this.transform.position = grabbedRope.transform.position + (grabbedRope.transform.forward + new Vector3(0.0f, -1.5f, 0.0f));
		}

		if((Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0.0f) && holding == true && grabbedRope.rigidbody.velocity.magnitude < 12.0f){
			grabbedRope.rigidbody.AddForce(transform.forward * 15);
			Debug.Log(grabbedRope.rigidbody.velocity.magnitude);
		}
		if((Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0.0f) && holding == true && grabbedRope.rigidbody.velocity.magnitude < 12.0f){
			grabbedRope.rigidbody.AddForce(-transform.forward * 15);
		}
		if(Input.GetKeyDown(KeyCode.E) || Input.GetAxis("Triggers") < 0.0f){
			if(Input.GetAxis("Triggers") < 0.0f){
				holdingJoy = true;
			}
			if(ropeRange == true && holding == false){
				grabbedRope = closestRope;
				holding = true;
				this.gameObject.GetComponentInChildren<HeadBobber>().enabled = false;
				grabbedRope.rigidbody.AddForce(transform.forward * 1000.0f);
			}

		}
		if(Input.GetKeyUp(KeyCode.E) || (Input.GetAxis("Triggers") == 0.0f && holdingJoy)){
			if(holding == true){
				grabbedRope = null;
				holding = false;
				this.gameObject.GetComponentInChildren<HeadBobber>().enabled = true;
				SendMessage("SetVelocity", transform.forward * 10.0f);
			}
		}

		//Used to warp to checkpoints
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			if(GameObject.Find("checkpoint1") != null){
				PlayerPrefs.SetString ("isDead", "true");
				GameObject.Find("checkpoint1").GetComponent<checkPointBehavior>().manualSave();
				SendMessage("respawnPlayer");
				Application.LoadLevel(Application.loadedLevel);

			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			if(GameObject.Find("checkpoint2") != null){
				PlayerPrefs.SetString ("isDead", "true");
				GameObject.Find("checkpoint2").GetComponent<checkPointBehavior>().manualSave();
				SendMessage("respawnPlayer");
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			if(GameObject.Find("checkpoint3") != null){
				PlayerPrefs.SetString ("isDead", "true");
				GameObject.Find("checkpoint3").GetComponent<checkPointBehavior>().manualSave();
				SendMessage("respawnPlayer");
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			if(GameObject.Find("checkpoint4") != null){
				PlayerPrefs.SetString ("isDead", "true");
				GameObject.Find("checkpoint4").GetComponent<checkPointBehavior>().manualSave();
				SendMessage("respawnPlayer");
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			if(GameObject.Find("checkpoint5") != null){
				PlayerPrefs.SetString ("isDead", "true");
				GameObject.Find("checkpoint5").GetComponent<checkPointBehavior>().manualSave();
				SendMessage("respawnPlayer");
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("Select"))
		{
			OVRDevice.ResetOrientation(0);
		}
	}
	public void inRange(GameObject rope){
		this.gameObject.GetComponentInChildren<HeadBobber>().enabled = false;
		closestRope = rope;
		ropeRange = true;
	}
	public void outRange(GameObject rope){
		if (rope == closestRope){
			closestRope = null;
			ropeRange = false;
		}
	}
}

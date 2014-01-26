
// simple fading script
// A texture is stretched over the entire screen. The color of the pixel is set each frame until it reaches its target color.

//Found on Wiki Unity
using UnityEngine;
using System.Collections;


public class spikeBehaviour : MonoBehaviour
{   

	
	void Update(){
	}

	
	 void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){

			Vector3 pushforce = other.transform.forward * -1;
			other.SendMessage("SetVelocity", pushforce * 10.0f);

		}
	}	
	
}
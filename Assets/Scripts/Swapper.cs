using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Swappable"){
			print (other.gameObject.name);
			other.gameObject.AddComponent<PlayerInput>();
			DestroyPlayerInput();
		}
	}


	void DestroyPlayerInput(){
		PlayerInput pinput = this.GetComponent<PlayerInput>();
		Destroy(pinput);
	}


}

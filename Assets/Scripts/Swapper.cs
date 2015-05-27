using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Swappable"){
			print (other.gameObject.name);

			this.gameObject.tag = "Swappable";
			other.gameObject.tag = "Player";

			other.gameObject.AddComponent<PlayerInput>();
			other.gameObject.AddComponent<Swapper>();

			DestroyPlayerInput();
			Destroy(this);
		}
	}


	void DestroyPlayerInput(){
		PlayerInput pinput = this.GetComponent<PlayerInput>();
		Destroy(pinput);
	}


}

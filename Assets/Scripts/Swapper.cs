using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Swappable"){
			SwapToObject(other.gameObject);
		}
	}


	void SwapToObject(GameObject goober){

	}


	void DestroyPlayerInput(){
		PlayerInput pinput = this.GetComponent<PlayerInput>();
		pinput.ChangeColor(Color.white);
		Destroy(pinput);
	}


}

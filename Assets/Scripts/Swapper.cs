using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {


	void Update(){
		if (Input.GetKeyDown(KeyCode.Space)){
			FindSwappables();
		}
	}

	void FindSwappables(){
		Collider[] colliders = Physics.OverlapSphere(this.transform.position, 2f);
		GameObject swappableObject = null;
		foreach (Collider c in colliders){
			if (c.tag == "Swappable"){
				swappableObject = c.gameObject;
			}
		}
		if (swappableObject != null){
			SwapToObject(swappableObject);
		}
	}


	void SwapToObject(GameObject goober){
		this.GetComponent<PlayerInput>().SwapToBody(goober);
	}


	void DestroyPlayerInput(){
		PlayerInput pinput = this.GetComponent<PlayerInput>();
		pinput.ChangeColor(Color.white);
		Destroy(pinput);
	}


}

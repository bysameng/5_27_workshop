using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {


	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Swappable"){
			print (other.gameObject.name);
		}
	}


}

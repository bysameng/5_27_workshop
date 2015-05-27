using UnityEngine;
using System.Collections;

public class Swapper : MonoBehaviour {


	void OnCollisionEnter(Collision other){
		print (other.gameObject.name);
	}


}

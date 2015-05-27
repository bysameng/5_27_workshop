using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour {

	private Rigidbody rbody;
	private Renderer rend;

	public float movementForce = 30f;

	void Start() {
		rbody = this.GetComponent<Rigidbody>();
		rend = this.GetComponent<Renderer>();

//		if (rbody == null){
//			rbody = this.gameObject.AddComponent<Rigidbody>();
//		}

		ChangeColor(Color.red);
	}
	
	void Update() {
		float h = Input.GetAxis("Horizontal") * movementForce;
		float v = Input.GetAxis("Vertical") * movementForce;

//		print ("Horizontal: " + h + " Vertical: " + v);

		Vector3 movement = new Vector3(h, 0f, v);
		rbody.AddForce(movement);
	}


	public void ChangeColor(Color c){
		rend.material.color = c;
	}



}












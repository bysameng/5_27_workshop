using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour {

	private Rigidbody rbody;
	private Renderer rend;

	public float movementForce;

	void Start () {
		rbody = this.GetComponent<Rigidbody>();
		rend = this.GetComponent<Renderer>();

//		if (rbody == null){
//			rbody = this.gameObject.AddComponent<Rigidbody>();
//		}
	}
	
	void Update () {
		float h = Input.GetAxis("Horizontal") * movementForce;
		float v = Input.GetAxis("Vertical") * movementForce;

//		print ("Horizontal: " + h + " Vertical: " + v);

		Vector3 movement = new Vector3(h, 0f, v);
		rbody.AddForce(movement);


		if (Input.GetKeyDown(KeyCode.F)){
			ChangeColor(Color.red);
		}
		if (Input.GetKeyDown(KeyCode.G)){
			ChangeColor(Color.blue);
		}

	}


	void ChangeColor(Color c)
	{
		rend.material.color = c;
	}


}












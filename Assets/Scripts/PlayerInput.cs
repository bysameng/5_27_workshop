using UnityEngine;
using System.Collections;


[DisallowMultipleComponent]
//[RequireComponent(typeof(Rigidbody))]
public class PlayerInput : MonoBehaviour {

	//this, since it's public, will show up in the inspector!
	public GameObject playerBody;

	//these will not show up in the inspector.
	//we put these here since we need to talk to these guys later!
	private Rigidbody rbody;
	private Renderer rend;

	//this will show up in the inspector.
	//the "= 30f" is basically a DEFAULT value that will only be set for NEW components.
	//changing this won't change components that already exist!
	public float movementForce = 30f;


	//Start will run when the object is created!
	//we also use it ourselves later.
	void Start() {

		//here we get the references to the components we want to talk to.
		//these references are like links or telephone wires that we can use to tell those components to do stuff.
		rbody = playerBody.GetComponent<Rigidbody>();
		rend = playerBody.GetComponent<Renderer>();

		//this is a fancier check, that will check if it's null.
		//if it is null, add a rigidbody component.
		//keep in mind that since this script is now attached to playerbrain, we don't want this
		//to add a new rigidbody to THIS gameobject.
		//instead, we would want to add a component to playerBody.gameObject.
//		if (rbody == null){
//			rbody = this.gameObject.AddComponent<Rigidbody>();
//		}

		//let's change the color of the current body to red.
		ChangeColor(Color.red);

		//let's set this script (the brain)'s parent to be the body.
		SetParentToBody();
	}


	//update runs every single little frame.
	void Update() {

		//here, we use Input.GetAxis(string) which is set up in the menu Edit->Project Settings->Input, we are using default setups.
		//we multiply by movementForce to give us some control over the force we are adding.
		float h = Input.GetAxis("Horizontal") * movementForce;
		float v = Input.GetAxis("Vertical") * movementForce;

//		print ("Horizontal: " + h + " Vertical: " + v);

		//here we create a new Vector3 which holds our h and v values.
		Vector3 movement = new Vector3(h, 0f, v);

		//we tell the rigidbody to add force based on the input we got.
		rbody.AddForce(movement);
	}


	//this function will change the color for us.
	public void ChangeColor(Color c){
		//this line of code tells the renderer's material to change the color.
		//this acutally changes the color.
		rend.material.color = c;
	}


	//this function will set this object (playerbrain)'s parent to be the new body.
	//then it will make sure that this, the player brain, is at the center of the new body.
	public void SetParentToBody(){
		this.transform.parent = playerBody.transform;
		this.transform.localPosition = new Vector3(0f, 0f, 0f);
	}


	//this function actually does the swapping.
	public void SwapToBody(GameObject g){
		//we set the color of this body back to white.
		ChangeColor(Color.white);

		//we set the playerbody to be the object we pass in
		playerBody = g;

		//we use our Start() function again, since it sets up the rbody and rend the way we want.
		Start();
	}

}












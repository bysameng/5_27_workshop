using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private float maxSpeed;
	private float currentSpeed;
	private float acceleration;
	private float deceleration;


	// Use this for initialization
	void Start () {
		maxSpeed = 10f;
		currentSpeed = 0f;
		acceleration = 2f;
		deceleration = 4f;
	}


	void Update(){
		bool isUpArrowPressed = Input.GetKey(KeyCode.UpArrow);

		if (isUpArrowPressed){
			currentSpeed += acceleration * Time.deltaTime;
			//currentSpeed = currentSpeed + acceleration * Time.deltaTime;
		}
		else{
			currentSpeed -= deceleration * Time.deltaTime;
			if (currentSpeed < 0){
				currentSpeed = 0;
			}
		}

		transform.position = transform.position + new Vector3(0f, 0f, currentSpeed) * Time.deltaTime;
	}



	

}

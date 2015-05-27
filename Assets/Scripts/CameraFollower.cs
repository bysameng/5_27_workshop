using UnityEngine;
using System.Collections;

//very simple camera follow script.
public class CameraFollower : MonoBehaviour {

	//these are public variables you must assign in the inspector!

	//objectToFollow is the actual object we are going to follow.
	public GameObject objectToFollow;

	//offset is just how far we want to be from the object we are following
	public Vector3 offset;


	// Update is called once per frame
	// this will set my (the attached camera) position to the ObjectToFollow position
	//and then move it by "offset" units.
	//then it will use the built-in function to force this object to look at the objectToFollow position.
	void Update () {
		transform.position = objectToFollow.transform.position + offset;
		transform.LookAt(objectToFollow.transform.position);
	}
}

using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public GameObject objectToFollow;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = objectToFollow.transform.position + offset;
		transform.LookAt(objectToFollow.transform.position);
	}
}

using UnityEngine;
using System.Collections;

//the swapper should only be on the playerbrain!
//this swapper takes care of swapping.
//when the player presses the SPACEBAR, we check for any swappable objects nearby.
//if there are any, we tell PlayerInput on this object to Swap to it!
public class Swapper : MonoBehaviour {

	PlayerInput pinput;

	//i will grab the playerinput that's on my playerbrain object.
	//i didn't put this in class, but this is just an easier way of doing things.
	//it's the same way we grabbed the rigidbody and the same way we grabbed the renderer in playerinput.
	void Start(){
		pinput = this.GetComponent<PlayerInput>();
	}


	//update will run every single frame of the game.
	//here we will check every single frame, and check "is the player pressing space?"
	//when the player presses space (only when the button is pressed, not if holding)
	//we will use our FindSwappables to find some things to swap to!
	void Update(){
		if (Input.GetKeyDown(KeyCode.Space)){
			FindSwappables();
		}
	}


	//this function will get everything around it into an array 
	//and then look through that array to see if any of those are swappable.
	void FindSwappables(){
		//here we use Physics.OverlapSphere.
		//it returns Collider[] so we must store it into a Collider[] variable. I named it "colliders"
		//the "2f" is just the RANGE of it.
		Collider[] colliders = Physics.OverlapSphere(this.transform.position, 2f);

		//here we make a new varaible to hold the object we'll swap to.
		//it's null because we haven't found a suitable one yet!
		//i do this so that if there is no swappableObject found, I know swappableObject will still be null.
		GameObject swappableObject = null;

		//I loop through each collider in my "colliders" variable that I got back from OverlapSphere.
		//for each collider i check its tag and see if it has tag "Swappable"
		//I also added a check to make sure that the body I'm swapping into isn't the body I'm currently in.
		//the double ampersand is the "AND" operator.
		foreach (Collider c in colliders){
			if (c.tag == "Swappable" && c.gameObject != pinput.playerBody){
				//if the tag check says it's swappable, I will set my swappableObject
				//(swappableObject was null before) setting swappableObject to be that object I found was swappable.
				swappableObject = c.gameObject;
			}
		}

		//this is AFTER the loop.
		//if i ever found an object with tag == "Swappable" inside of the loop, 
		//I would have assigned it to swappableObject.
		//therefore, if swappableObject is NOT null, then I will use my swap function.
		if (swappableObject != null){
			SwapToObject(swappableObject);
		}
	}


	//this is my swap function inside of swapper. 
	//it tells the playerinput to actually do the swapping.
	void SwapToObject(GameObject goober){
		Debug.Log("Swapping to " + goober.name);
		this.GetComponent<PlayerInput>().SwapToBody(goober);
	}


	//this is deprecated (not being used anymore, pretty much)
	void DestroyPlayerInput(){
		PlayerInput pinput = this.GetComponent<PlayerInput>();
		pinput.ChangeColor(Color.white);
		Destroy(pinput);
	}


}

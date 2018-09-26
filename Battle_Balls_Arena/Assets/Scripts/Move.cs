using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public Camera MyCamera;
	public Rigidbody rb;
	private float noMovementThreshold = 0.001f;
	private const int noMovementFrames = 3;
	Vector3[] previousLocations = new Vector3[noMovementFrames];
	private bool isMoving;

	 //Let other scripts see if the object is moving
	public bool IsMoving
	{
		get{ return isMoving; }
	}
	
	void Awake()
	{
		//For good measure, set the previous locations
		for(int i = 0; i < previousLocations.Length; i++)
		{
			previousLocations[i] = Vector3.zero;
		}
	}
	
	void Update()
	{
		//Store the newest vector at the end of the list of vectors
		for(int i = 0; i < previousLocations.Length - 1; i++)
		{
			previousLocations[i] = previousLocations[i+1];
		}
		previousLocations[previousLocations.Length - 1] = transform.position;
	
		//Check the distances between the points in your previous locations
		//If for the past several updates, there are no movements smaller than the threshold,
		//you can most likely assume that the object is not moving
		for(int i = 0; i < previousLocations.Length - 1; i++)
		{
			if(Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= noMovementThreshold)
			{
				//The minimum movement has been detected between frames
				isMoving = true;
				break;
			}
			else
			{
				isMoving = false;
			}
		}
	}







	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0)) {
			Vector3 movement = MyCamera.transform.forward * 300;
			rb.AddForce(movement);
		}
	}
}

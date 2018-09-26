using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
	public Camera MyCamera;
	public Rigidbody rb;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton(0)) {
			Vector3 movement = MyCamera.transform.forward * 300;
			rb.AddForce(movement);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorPowerUp : MonoBehaviour {

	public float intervalo;
	public GameObject powerUp;

	private Vector3 validPos;
	BoxCollider powerUpCollider;

	// Use this for initialization
	void Awake () {
		powerUpCollider = powerUp.GetComponent<BoxCollider>();
		GerarPowerUp();
	}
	
	// Update is called once per frame
	void GerarPowerUp () {
		Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(45, 0, 45);

		do {
			validPos = new Vector3(Random.Range(-29f, 29f), -18.2f, Random.Range(-29f, 29f));
		} while (Physics.CheckBox(validPos, powerUpCollider.size, transform.rotation));

		GameObject instance = Instantiate(powerUp, validPos, rotation);
	}
}

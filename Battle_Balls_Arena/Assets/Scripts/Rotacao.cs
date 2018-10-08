using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour {
	
	CalculadoraJogador calc;

	// Update is called once per frame
	void Update() {
		transform.Rotate(Vector3.up, 3 * Time.deltaTime * Mathf.Rad2Deg, Space.World);
	}

	void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
			calc = other.GetComponent<CalculadoraJogador>();

			if (tag == "AtaqueUp") {
				calc.playerMaxStrength++;
			}
			else {
				calc.playerMaxHealth += 30;
				calc.playerHealth += 30;
			}

			calc.UpdateStats();
			Destroy(gameObject);
		}
    }
}

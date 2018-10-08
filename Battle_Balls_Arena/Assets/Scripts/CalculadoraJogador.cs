using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculadoraJogador : MonoBehaviour {

	[HideInInspector]
	public float playerHealth, playerMaxHealth, playerMaxStrength;
	public Text playerAtaque, playerVida;
	public Slider playerBar;
	Mechanics mech;

	PowerBar powerBar;
	public GameObject mechObj;

	private Rigidbody rb;
	// Use this for initialization
	void Awake () {
		mech = mechObj.GetComponent<Mechanics>();
		powerBar = gameObject.GetComponent<PowerBar>();

		playerHealth = 100;
		playerMaxHealth = 100;
		playerMaxStrength = 5;
		powerBar.m_MaxForce = 160 * playerMaxStrength;

		UpdateStats();
	}
	
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Player" && enabled) {
			float advAtaque = other.gameObject.GetComponent<CalculadoraJogador>().playerMaxStrength;
			EfetuarDano(other.impulse.magnitude * advAtaque);
		}
	}

	public void UpdateStats() {
		AtualizaVida();
		playerAtaque.text = "Ataque: " + playerMaxStrength.ToString();
		playerBar.maxValue = playerMaxHealth;
		playerBar.value = playerHealth;
	}

	void AtualizaVida() {
		playerVida.text = playerHealth.ToString();
	}

	public void EfetuarDano(float dano) {
		playerHealth -= Mathf.FloorToInt(dano);

		AtualizaVida();
	}

	void AtaqueUp() {

	}
}

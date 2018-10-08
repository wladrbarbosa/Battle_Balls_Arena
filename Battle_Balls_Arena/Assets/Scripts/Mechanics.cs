using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mechanics : MonoBehaviour {

	public enum Turn {Player1, Player2, Player3, Player4, Player5, Player6};
	public Turn turno_atual;
	public GameObject player1CamRig, player2CamRig, player1, player2;
	public Text player1Ataque, player2Ataque, player1Vida, player2Vida;
	public Slider player1Bar, player2Bar;
	private int qtdePlayers = 2;//System.Enum.GetValues(typeof(Turn)).Length;
	private PowerBar powerBar1, powerBar2;
	private CalculadoraJogador jogCalc1, jogCalc2;

	// Use this for initialization
	void Awake () {
		turno_atual = (Turn)Random.Range(0, 2);

		powerBar1 = player1.GetComponent<PowerBar>();
		powerBar2 = player2.GetComponent<PowerBar>();
		jogCalc1 = player1.GetComponent<CalculadoraJogador>();
		jogCalc2 = player2.GetComponent<CalculadoraJogador>();

		ChangePlayerFocus();
	}
	void ChangePlayerFocus() {
		if (turno_atual == Turn.Player1) {
			player1CamRig.SetActive(true);
			player2CamRig.SetActive(false);
			powerBar1.enabled = true;
			powerBar2.enabled = false;
			jogCalc1.enabled = false;
			jogCalc2.enabled = true;
		}
		else {
			player1CamRig.SetActive(false);
			player2CamRig.SetActive(true);
			powerBar1.enabled = false;
			powerBar2.enabled = true;
			jogCalc1.enabled = true;
			jogCalc2.enabled = false;
		}
	}

	public void ChangeTurn() {
		turno_atual += 1;

		if ((int)turno_atual == qtdePlayers)
			turno_atual = 0;

		ChangePlayerFocus();
	}
}

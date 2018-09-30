using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {

	public GameObject Mode; //Game object Gamemode
	public GameMode Gamescript; //script del Gamemode
	public GameObject Player1;
	public GameObject Player2;
	public Player_Movement pscript1;
	public Player_Movement pscript2;
	public GameObject txtWinner; //objeto de textoganador
	public GameObject txtKb1;
	public GameObject txtKb2;
	Text winner; //texto que dice el ganador
	Text Knockback1;
	Text Knockback2;

	int timerCristal;

	public static bool cpwinner;
	// Use this for initialization
	void Start () {

		cpwinner = false;

		Mode = GameObject.Find("GameMode");
		txtWinner = GameObject.Find("txtWin");
		Player1 = GameObject.Find("Character01");
		Player2 = GameObject.Find("Character02");
		txtKb1 = GameObject.Find("txtKnock1");
		txtKb2 = GameObject.Find("txtKnock2");

		pscript1 = new Player_Movement ();
		pscript2 = new Player_Movement ();
		pscript1 = Player1.GetComponent<Player_Movement> ();
		pscript2 = Player2.GetComponent<Player_Movement> ();
		Gamescript = new GameMode ();
		Gamescript = Mode.GetComponent<GameMode> ();
		winner = txtWinner.GetComponent<Text> ();
		Knockback1 = txtKb1.GetComponent<Text> ();
		Knockback2 = txtKb2.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Gamescript.mode == "deathmatch")
			winner.text = "Peleen!";
		else {
			if(Cristal.last_hit < 4){
				timerCristal = (int)Cristal.timerPlayer[Cristal.last_hit];
				winner.text = timerCristal.ToString();
			}
			else
				winner.text = "Peleen!";
		}
		Knockback1.text = (pscript1.knockbackPercentage * 10).ToString () + "%";
		Knockback2.text = (pscript2.knockbackPercentage * 10).ToString () + "%";

		if (Gamescript.survivors == 1 || cpwinner == true) {
			winner.text = "Gano el Jugador"+Gamescript.winner.ToString();
			cpwinner = false;
		}
	}

	//void Animation()
}

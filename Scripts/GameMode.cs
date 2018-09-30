using UnityEngine;
using System.Collections;

public class GameMode : MonoBehaviour 
{
	public Cristal cristal;
	public GameObject[] Players;
	public int numPlayers;
	public Player_Movement[] playerScript;
	public int survivors;
	public uint winner;
	public uint gameWinner;
	public string mode;
	public int[] playerWins;
	public Transform[] spawns;
	public float timer;
	public float respawnTimer;
	public static bool reset;

	public float[] deathTimer;
	// Use this for initialization
	void Start () {
		timer = 0;
		survivors = numPlayers;
		playerScript = new Player_Movement[numPlayers];
		Players = new GameObject[numPlayers];
		playerWins = new int[numPlayers];
		for (int a = 0; a < numPlayers; a++) {
			int b = a + 1;
			Players[a] = GameObject.Find("Character0"+ b.ToString());
			playerScript[a] = Players[a].GetComponent<Player_Movement>();
			playerWins[a] = 0;
		}
		reset = false;

		deathTimer = new float[2];

		mode = CharSelect.ModoDeJuegoElegido;
		Debug.Log (mode);
	}
	
	// Update is called once per frame
	void Update () {
		if(mode == "cristal")
			CP ();
		else
			DM ();
	}

	void Respawn(){
		for (int a = 0; a < numPlayers; a++){
			int rng = Random.Range(0,7);
			int rng2 = Random.Range(0,7);
		swag:
			if(rng2==rng){rng2=Random.Range(0,7);goto swag;}
			playerScript[a].death = false;
			Players[a].transform.position = spawns[rng].position;
			playerScript[a].knockbackPercentage = 0;
		}
	}

	void DM(){
		if (survivors != 1) {
			for (int x = 0; x < numPlayers; x++) {
				if (playerScript [x].death) {
					survivors--;
					} else {
					winner = playerScript [x].PlayerID;
				}

				if(playerWins[x] == 5){
					gameWinner = playerScript [x].PlayerID;
					Application.LoadLevel("menu5");
				}
			}
		}else{
			Debug.Log ("JUGADOR "+winner+" ES EL GANADOR!");
			timer += Time.deltaTime;
		}
		if (timer > respawnTimer) {
			timer = 0;
			playerWins[(winner - 1)]++;
			Respawn();
			survivors = numPlayers;
		}
	}
	void CP()
	{
		for (int x = 0; x < numPlayers; x++) {
			if (playerScript [x].death) {
				deathTimer[x] += Time.deltaTime;

				if(deathTimer[x] > 5){
					deathTimer[x] = 0;
					int rng = Random.Range(0,7);
					playerScript[x].death = false;
					Players[x].transform.position = spawns[rng].position;
					playerScript[x].knockbackPercentage = 0;
				}
			} 
		}

		if (cp_player_won ()) {
			timer += Time.deltaTime;
			Debug.Log ("won");

			//find greatest
			int cp_win =0; int cp_id=1;
			for(int i = 0;i<4;i++)
				if(Cristal.timerPlayer[i] <= 0)
			{	
				cp_id=i;
			}
			Debug.Log (cp_id);
			winner = (uint)cp_id;
			Hud.cpwinner = true;
		}

		if (timer > respawnTimer) 
		{
			//cp_id es el id del ganador
			//pone el respawn y todo aca
			Respawn();
			timer = 0;
			int length = Cristal.timerPlayer.Length;
			for(int x = 0; x < length; x++){
				Cristal.timerPlayer[x] = 30;
			}
			playerWins[(int)winner -1]++;
			if(playerWins[(int)winner -1] >= 5)
				Application.LoadLevel("menu5");
			reset = true;
		}
	}

	bool cp_player_won()
	{
		for (int e = 0; e < 4; e++) 
		{
			if(Cristal.timerPlayer[e] <= 0){
				Debug.Log(Cristal.timerPlayer[e]);
				return true;
			}
		}
		return false;
	}
}

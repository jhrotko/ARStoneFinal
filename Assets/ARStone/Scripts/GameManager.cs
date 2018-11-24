using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public PlayerManager player;
	public List<PlayerMonster> playerHand;
	public TextMesh Title;
	public TextMesh Turn;
	public TextMesh Notification;
	private float timer;
	public bool PlayerTurn;
	public ZombieManager PlayerCard;
	
	// Use this for initialization
	void Start () {
		Title.text = "Starting Game";
		PlayerTurn = true;

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		
		if(timer >= 2.0f) {
			Title.text = "";
			timer = 0.0f;
		}
		//Debug.Log("Player Life " + player.GetLife());
		if(player.GetLife() <= 0) {
			Title.text = "Game Over";
		}

		if(PlayerTurn) {
			//Debug.Log("Player Turn");
			Turn.text = "Your Turn";
		} else {
			Debug.Log("ENEMY TURN");
			Turn.text = "Enemie's Turn";

		}

	}
}

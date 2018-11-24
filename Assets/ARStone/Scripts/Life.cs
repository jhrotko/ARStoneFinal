using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Life : MonoBehaviour {

	public Text life_text;
	public int life;

	// Use this for initialization
	void Start () {
		life = 30;
		life_text.text = "Enemy Life: " + life.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void updateLife(int damage){
		life -= damage;
		life_text.text = "Enemy Life: " + life.ToString();
	}
}

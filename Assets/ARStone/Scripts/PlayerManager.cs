using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour {
    private int Life;
    public Text life_text;
	// Use this for initialization
	void Start () {
        Life = 30;
        life_text.text = "Player Life: " + Life.ToString();
	}

    public void DecreaseLife(int delta)
    {
        Life -= delta;
        life_text.text = "Player Life: " + Life.ToString();
    }

    public int GetLife()
    {
        return Life;
    }
}

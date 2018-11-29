using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour {
    private int Life;
    private float currentPercentage;
    public Image Bar;
    public Text life_text;

    public int MaxHP;

	// Use this for initialization
	void Start () {
        Life = MaxHP;
        life_text.text = "100%";
	currentPercentage = 1;
	Bar.fillAmount = currentPercentage;
	}

    public void DecreaseLife(int delta)
    {
        Life -= delta;
	if(Life <= 0){
		Life = 0;
		currentPercentage = 0;

	} 
        else{
		currentPercentage = (float)Life/MaxHP;
	}

        life_text.text = string.Format("{0} %", Mathf.RoundToInt(currentPercentage * 100));
	Bar.fillAmount = currentPercentage;
    }

    public float GetPercentage(){
	return currentPercentage;
    }
    public int GetLife()
    {
        return Life;
    }
}

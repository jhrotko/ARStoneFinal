using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCT : MonoBehaviour {

    public GameObject DragonText;
    public GameObject ZombieText;
    public GameObject DruidText;
    float time = 0.0f;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3.5f)
        {
            ZombieText.GetComponent<TextMesh>().text = "";
            ZombieText.GetComponent<TextMesh>().text = "";
            DruidText.GetComponent<TextMesh>().text = "";
            DruidText.GetComponent<TextMesh>().text = "";
            DragonText.GetComponent<TextMesh>().text = "";
            DragonText.GetComponent<TextMesh>().text = "";
        }
    }
    private void Move()
    {
        transform.Translate(Vector2.up * 1 * Time.deltaTime);
    }

    public void SetPosition(PlayerMonster pm, int damage)
    {
        if (damage >= 0)
        {
            pm.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = damage.ToString();
            time = 0;
        }/*
        else
        {
            pm.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMesh>().text = damage.ToString();
        }*/          
    }

    public void SetPosition(GameObject pm, int damage)
    {
        if (damage >= 0)
        {
           pm.transform.GetChild(4).gameObject.GetComponent<TextMesh>().text = damage.ToString();
           time = 0;
        }/*
        else
        {
            pm.transform.GetChild(5).gameObject.GetComponent<TextMesh>().text = damage.ToString();
        }*/
    }
}

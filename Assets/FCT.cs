using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Move();
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
        }
        else
        {
            pm.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMesh>().text = damage.ToString();
        }               
    }

    public void SetPosition(GameObject pm, int damage)
    {
        if (damage >= 0)
        {
            pm.transform.GetChild(4).gameObject.GetComponent<TextMesh>().text = damage.ToString();
        }
        else
        {
            pm.transform.GetChild(5).gameObject.GetComponent<TextMesh>().text = damage.ToString();
        }
    }
}

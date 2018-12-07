using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.up * 1 * Time.deltaTime);
    }

    public void SetPosition(PlayerMonster pm, int damage)
    {
        Transform transform = pm.gameObject.transform;
        gameObject.GetComponent<TextMesh>().transform.position = transform.position;
        gameObject.GetComponent<TextMesh>().text = damage.ToString();
    }

    public void SetPosition(GameObject pm, int damage)
    {   
        Transform transform = pm.gameObject.transform;
        gameObject.transform.GetChild(0).GetComponent<TextMesh>().transform.position = transform.position;
        gameObject.transform.GetChild(0).GetComponent<TextMesh>().text = damage.ToString();
    }
}

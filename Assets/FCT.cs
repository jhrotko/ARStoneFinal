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
        //transform = pm.gameobject.transform;
        gameObject.GetComponent<TextMesh>().text = damage.ToString();
    }
}

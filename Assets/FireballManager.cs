using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballManager : MonoBehaviour {


    public int damage = 4;
    public int life = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (life <= 0)
        {
            Debug.Log("Fireball used");
            Destroy(gameObject);
    
        }
    }
}

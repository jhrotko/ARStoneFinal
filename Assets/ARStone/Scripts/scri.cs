using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scri : MonoBehaviour {

    float lol = 0.0f;
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Zombie is dieing   " +  lol);
        lol += 1;

        

        if (col.gameObject.name == "Zombie")
        {
            Debug.Log("Zombie is dieing");
        }
    }
}

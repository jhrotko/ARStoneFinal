using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleTest : MonoBehaviour {

    public Material ButtonIdle;
    public Material ButtonSelected;

    GameObject modifiedGameObject;

    // Use this for initialization
    void Start () {
		
	}
    /*
    private void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;

        if(target.name == "AttackButton")
        {
            Debug.Log("IM CLICKING THE BUTTON!");
        }
    }*/

    private void FixedUpdate()
    {
        /* Vector3 fwd = transform.TransformDirection(Vector3.forward);

         Debug.Log("Did Hit");
         if (Physics.Raycast(transform.position, fwd, 10))
             print("There is something in front of the object!");*/
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 10, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            Debug.Log("Did Hit " +  hit.transform.gameObject.name);

            if(hit.transform.gameObject.name == "Zombie")
            {
                Debug.Log("I hited the zoombie");
                revertButtonMaterial();

            }
            else if( hit.transform.gameObject.name == "ZAttackButton")
            {
                hit.transform.gameObject.GetComponent<MeshRenderer>().material = ButtonSelected;
                modifiedGameObject = hit.transform.gameObject;
            }

            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white);
            Debug.Log("Did not Hit");

            revertButtonMaterial();

        }
    }

    private void revertButtonMaterial()
    {
        if (modifiedGameObject != null)
        {
            if (modifiedGameObject.name == "ZAttackButton")
            {
                modifiedGameObject.GetComponent<MeshRenderer>().material = ButtonIdle;
                modifiedGameObject = null;
            }
        }
    }

}

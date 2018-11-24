using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticleTest : MonoBehaviour {

    public Material ButtonIdle;
    public Material ButtonOvered;
    public Material ButtonSelected;
    private bool attackSelected;
    private bool defendSelected;

    GameObject modifiedGameObject;
    private float Attacktimer;
    private float Defendtimer;

    private void FixedUpdate()
    {
     
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

            
            if( hit.transform.gameObject.name == "AttackButton")
            {

                if (Attacktimer < 2.0f)
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material = ButtonOvered;
                    Attacktimer += Time.deltaTime;

                    if (modifiedGameObject != null && modifiedGameObject.name == "DefendButton" && modifiedGameObject.transform.parent == hit.transform.parent)
                    { 
                        if (!defendSelected)
                        {
                            modifiedGameObject.GetComponent<MeshRenderer>().material = ButtonIdle;
                            modifiedGameObject = hit.transform.gameObject;
                            Defendtimer = 0.0f;
                        }
                    }
                }

                else
                {
                    PlayerMonster creature = getCreature(hit);
                    //Must be the buttons from the same creature and Defend Button cannot be slected
                    if (creature.GetDefending())
                    {
                        creature.Defending(false);
                        hit.transform.gameObject.transform.parent.Find("DefendButton").GetComponent<MeshRenderer>().material = ButtonIdle;
                        Defendtimer = 0.0f;
                        defendSelected = false;

                    } 
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material = ButtonSelected;
                    attackSelected = true;
                    creature.Attacking(true);
                }
                modifiedGameObject = hit.transform.gameObject;
            }

            else if (hit.transform.gameObject.name == "DefendButton")
            {
               //Hover Button
                if (Defendtimer < 2.0f)
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().material = ButtonOvered;
                    Defendtimer += Time.deltaTime;

                    //Turn the other button idle
                    if (modifiedGameObject != null && modifiedGameObject.name == "AttackButton" && modifiedGameObject.transform.parent == hit.transform.parent)
                    {
                        if(!attackSelected)                            
                        {
                            modifiedGameObject.GetComponent<MeshRenderer>().material = ButtonIdle;
                            modifiedGameObject = hit.transform.gameObject;
                            Attacktimer = 0.0f;
                        }
                    }
                }

                //Select Button
                else
                {
                    PlayerMonster creature = getCreature(hit);
                    if (creature.GetAttacking())
                    {
                        Debug.Log("dsfsdfsdfsdfsdfsdfjhgsdjhfjdsgfhjsdgfhjsdgfjhsdgjhfgshjdgfhsjdgfjshdgfhsjd");
                        creature.Attacking(false);
                        attackSelected = false;
                        hit.transform.gameObject.transform.parent.Find("AttackButton").GetComponent<MeshRenderer>().material = ButtonIdle;
                        Attacktimer = 0.0f;
                    }

                    hit.transform.gameObject.GetComponent<MeshRenderer>().material = ButtonSelected;
                    defendSelected = true;
                    creature.Defending(true);

                    Debug.Log(hit.transform.gameObject.transform.parent.gameObject.name + " " + creature.GetDefending());

                }
                modifiedGameObject = hit.transform.gameObject;
            }
            else
            {
                revertButtonMaterial();
            }
        }

        //Did not hit a Button
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.white);
            //Debug.Log("Did not Hit");
            revertButtonMaterial();

        }
    }

    private void revertButtonMaterial()
    {
        if (modifiedGameObject != null)
        {
            if (modifiedGameObject.name == "AttackButton" && !attackSelected)
            {
                modifiedGameObject.GetComponent<MeshRenderer>().material = ButtonIdle;
                //modifiedGameObject = null;
                Attacktimer = 0.0f;
            }
            else if (modifiedGameObject.name == "DefendButton" && !defendSelected)
            {
                modifiedGameObject.GetComponent<MeshRenderer>().material = ButtonIdle;
                //modifiedGameObject = null;
                Defendtimer = 0.0f;
            }
            
        }
    }

    private PlayerMonster getCreature(RaycastHit hit)
    {
        string creatureName = hit.transform.gameObject.transform.parent.gameObject.name;
        creatureName = creatureName.Substring(3, creatureName.Length - 3);

        PlayerMonster creature = GameObject.Find(creatureName).GetComponent<PlayerMonster>();
        Debug.Log(" Creature name: " + creatureName);
        return creature;
    }

}

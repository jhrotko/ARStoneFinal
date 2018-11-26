using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragonManager : Boss {

    /*public int life = 30;
    public int damage = 3;
    private float timer = 0.0f;
    private float timerMax = 3.0f;
    public TextMesh lifeText;
    public TextMesh damageText;
    public GameManager gm;


    // Use this for initialization
    void Start()
    {
        lifeText.text = "" + life;
        damageText.text = "" + damage;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        lifeText.text = "" + life;
        damageText.text = "" + damage;
        
        if (!gm.PlayerTurn && timer >= timerMax){
            gm.PlayerCard.gameObject.GetComponent<ZombieManager>().life -= damage;
            gm.Notification.text = "Dragon dealt 3 to Zombie";
            // Debug.Log("Collision with Zombie - gave attackSelected, zombie life= " + col.gameObject.GetComponent<ZombieManager>().life);
            timer = 0.0f;
            gm.PlayerTurn = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Zombie" && gm.PlayerTurn)
        {
            Debug.Log("Collision with Zombie");
            life -= col.gameObject.GetComponent<ZombieManager>().damage;
            gm.Notification.text = "Zombie dealt 2 to Dragon";
            Debug.Log("Collision with Zombie - received attackSelected, dragon life= " + life);
            gm.PlayerTurn = false;
            Debug.Log("yo dragon");
            timer = 0.0f;
        }

        else if ( col.gameObject.name == "Fireball" && gm.PlayerTurn)
        {
            Debug.Log("Collision with Fireball");
            life -= col.gameObject.GetComponent<FireballManager>().damage;
            gm.Notification.text = "Fireball dealt 4 to Dragon";
            Debug.Log("Collision with Fireball - received attackSelected, dragon life= " + life);
            col.gameObject.GetComponent<FireballManager>().life -= damage;
            timer = 0.0f;
        }

        if(life<=0){
            Destroy(gameObject);
        }

    }*/
}
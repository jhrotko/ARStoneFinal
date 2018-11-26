using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public abstract class Monster : MonoBehaviour
{

    private int total_life;
    public int damage = 50;
    public int life = 50;
    //public int player_life = 30;
    public TextMesh lifeText;
    public TextMesh damageText;
    private float timer = -1;


    // Use this for initialization
    void Start()
    {
        total_life = life;
        lifeText.text = "" + life;
        damageText.text = "" + damage;
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = "" + life;
        damageText.text = "" + damage;

        if (timer > -1)
        {
            timer += Time.deltaTime;
            if (timer > 5.0f)
            {
                Debug.Log("Im being destroyed");
                timer = -1;
            }
        }

        if (life <= 0)
        {
            lifeText.transform.parent.gameObject.SetActive(false);
            damageText.transform.parent.gameObject.SetActive(false);

            GameObject parent = gameObject.transform.parent.gameObject;
            parent.transform.Find("AttackButton").gameObject.SetActive(false);
            parent.transform.Find("DefendButton").gameObject.SetActive(false);

            gameObject.SetActive(false);
            Debug.Log("I am dead da silva");
        }
    }

    public void DecreaseLife(int delta)
    {
        life -= delta;
    }

    public int GetDamage()
    {
        return damage;
    }

    public int GetLife()
    {
        return life;
    }

    public int GetTotalLife()
    {
        return total_life;
    }
}



public abstract class Boss : Monster
{

    void Update()
    {
        lifeText.text = "" + life;
        damageText.text = "" + damage;
    }

    public void BossTurn(List<PlayerMonster> targets)
    {
        foreach(PlayerMonster monster in targets)
        {
            //Boss only attacks Creatures that are not Defending
            if(!monster.GetDefending())
            {
                Debug.Log(monster + " attacking !");
                monster.DecreaseLife(damage);
                life -= monster.GetDamage();
            }
        }
    }
}
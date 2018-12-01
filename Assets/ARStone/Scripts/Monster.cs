using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public abstract class Monster : MonoBehaviour
{
    protected int old_life;
    protected int total_life;
    public int damage = 50;
    public int life = 50;
    //public int player_life = 30;
    public TextMesh lifeText;
    public TextMesh damageText;
    private float timer = -1;
    private float deadTimer;


    // Use this for initialization
    void Start()
    {
        total_life = life;
        old_life = life;
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
            deadTimer += Time.deltaTime;

            if(deadTimer >= 3.0f)
            {
                lifeText.transform.parent.gameObject.SetActive(false);
                damageText.transform.parent.gameObject.SetActive(false);

                GameObject parent = gameObject.transform.parent.gameObject;
                parent.transform.Find("AttackButton").gameObject.SetActive(false);
                parent.transform.Find("DefendButton").gameObject.SetActive(false);
                
                gameObject.SetActive(false);
                Debug.Log("I am dead da silva");
                deadTimer = 0.0f;
            }

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
    public AudioSource AttackSound;
    void Update()
    {
        lifeText.text = "" + life;
        damageText.text = "" + damage;

        if(life <= 0)
        {
            Animator anim = GetComponent<Animator>();
            anim.Play("Death");
        }
    }

    public void BossTurn(List<PlayerMonster> targets)
    {
        Animator anim = GetComponent<Animator>();
        anim.Play("Damaged");

        bool SomeAttacked = false;
        foreach (PlayerMonster monster in targets)
        {
            //Boss only attacks Creatures that are not Defending
            if(!monster.GetDefending())
            {
                SomeAttacked = true;
                Debug.Log(monster + " attacking !");
                monster.DecreaseLife(damage);
                life -= monster.GetDamage();

                if(monster.GetLife() <= 0)
                {
                    monster.PlayDead();
                }
            }
        }

        if(SomeAttacked)
        {
            anim.Play("Damaged");
        } else
        {
            anim.Play("Attack");
            AttackSound.Play();
        }
    }
}
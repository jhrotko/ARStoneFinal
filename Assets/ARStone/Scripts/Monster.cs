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
    public FCT fct;

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

    public void IncreaseDamage(int delta)
    {
       damage += delta;
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
    public AudioSource ChargedAttackSound;
    public AudioSource AirAttackSound;
    private static readonly System.Random getrandom = new System.Random();
    private bool charging = false;
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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Spell")
        {
            life -= 4;
            gameObject.transform.GetChild(5).gameObject.GetComponent<TextMesh>().text = "-4";
            Destroy(col.gameObject);
            gameObject.transform.GetChild(3).gameObject.SetActive(true);    
        }
    }
        public void BossTurn(List<PlayerMonster> targets)
    {
        Animator anim = GetComponent<Animator>();
        if (!charging)
        {
            
            int randomNumber = getrandom.Next(100);

            if (randomNumber > 40)
            {

                foreach (PlayerMonster monster in targets)
                {
                    //Boss only attacks Creatures that are not Defending
                    if (!monster.GetDefending())
                    {
                        
                        life -= monster.GetDamage();
                        fct.SetPosition(monster, monster.GetDamage());
                        fct.SetPosition(gameObject, -monster.GetDamage());

                        if (life > 0)
                        {
                            Debug.Log(monster + " attacking !");
                            monster.DecreaseLife(damage);
                            fct.SetPosition(monster, -damage);
                            fct.SetPosition(gameObject, damage);
                        }
                        if (monster.GetLife() <= 0)
                        {
                            monster.PlayDead();
                        }
                        
                    }
                }

                if (life > 0) { 
                    AirAttackSound.Play();
                    anim.Play("Flying_Attack");
                }
            }
            else
            {
                
                foreach (PlayerMonster monster in targets)
                {
                    //Boss only attacks Creatures that are not Defending
                    if (!monster.GetDefending())
                    {
                        life -= monster.GetDamage();
                        fct.SetPosition(gameObject, -monster.GetDamage());
                        fct.SetPosition(monster, monster.GetDamage());

                        if (monster.GetLife() <= 0)
                        {
                            monster.PlayDead();
                        }
                    }
                }
                if (life > 0)
                {
                    anim.Play("Landing");
                    charging = true;
                }
            }
        }
        else
        {
            charging = false;
            
            foreach (PlayerMonster monster in targets)
            {
                //Boss only attacks Creatures that are not Defending
                if (!monster.GetDefending())
                {
                    Debug.Log(monster + " charge attacking !");
                   
                    life -= monster.GetDamage();
                    fct.SetPosition(gameObject, -monster.GetDamage());
                    fct.SetPosition(monster, monster.GetDamage());

                    if (life > 0)
                    {
                        monster.DecreaseLife(damage * 3);
                        fct.SetPosition(monster, -(damage * 3));
                        fct.SetPosition(gameObject, damage * 3);


                        if (monster.GetLife() <= 0)
                        {
                            monster.PlayDead();
                        }
                    }

                }
                else
                {
                    if (life > 0)
                    {
                        monster.DecreaseLife(damage);
                        fct.SetPosition(monster, -damage);
                        fct.SetPosition(gameObject, damage);

                        if (monster.GetLife() <= 0)
                        {
                            monster.PlayDead();
                        }
                    }
                }
            }
            if (life > 0)
            {
                anim.Play("Attack");
                ChargedAttackSound.Play();
            }
        }

    }


}
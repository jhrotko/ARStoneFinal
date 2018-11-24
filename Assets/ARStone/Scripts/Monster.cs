using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            /*player.DecreaseLife(total_life);
            //player.DecreaseLife(30);
            //Debug.Log("Zombie dead, player life =" + player.GetLife());
            lifeText.gameObject.SetActive(false);
            damageText.gameObject.SetActive(false);
            GameObject.Find("ZAttackStatus").SetActive(false);
            GameObject.Find("ZLifeStatus").SetActive(false);
            Destroy(gameObject);*/
            Debug.Log("I am dead da silva");
        }
    }
}

public abstract class PlayerMonster: Monster
{
    private bool attacking = false;
    private bool defending = false;

    private float AttackTimer = 0.0f;
    private float DefendTimer = 0.0f;

    public float GetAttackTimer()
    {
        return AttackTimer;
    }

    public float GetDefendTimer()
    {
        return DefendTimer;
    }

    public void SetAttackTimer(float time)
    {
        AttackTimer = time;
    }

    public void SetDefendTimer(float time)
    {
        DefendTimer = time;
    }

    public void Attacking(bool atck)
    {
        attacking = atck;
    }

    public bool GetAttacking()
    {
        return attacking;
    }

    public void Defending(bool dfnd)
    {
        defending = dfnd;
    }

    public bool GetDefending()
    {
        return defending;
    }
}

public abstract class Boss: Monster
{

}
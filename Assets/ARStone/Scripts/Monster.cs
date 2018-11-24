using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
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
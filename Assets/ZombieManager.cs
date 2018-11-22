using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : Monster {

    private int total_life;
    public int damage = 50;
    public int life = 50;
    //public int player_life = 30;
    public TextMesh lifeText;
    public TextMesh damageText;
    public PlayerManager player;
    public ArmorManager armour;
    public WeaponManager weapon;
    private float timer = -1;
    public GameManager gm;

    // Use this for initialization
    void Start () {
        gm.PlayerCard = this;
        total_life = life;
        lifeText.text = "" + life;
        damageText.text = "" + damage;
	}
	
	// Update is called once per frame
	void Update () {

        lifeText.text = "" + life;
        damageText.text = "" + damage;

        if(timer > -1)
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
            player.DecreaseLife(total_life);
            //player.DecreaseLife(30);
            Debug.Log("Zombie dead, player life =" + player.GetLife());
            lifeText.gameObject.SetActive(false);
            damageText.gameObject.SetActive(false);
            GameObject.Find("ZAttackStatus").SetActive(false);
            GameObject.Find("ZLifeStatus").SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Armour_Helmet")
        {
            life += armour.GetBuff();
            lifeText.color = Color.green;
            timer = 0;
            armour.gameObject.SetActive(false);
        } else if(collision.gameObject.name == "Holo_Sword_FBX"){
            damage += weapon.GetBuff();
            damageText.color = Color.red;
            timer = 0;
            weapon.gameObject.SetActive(false);
        }
    }
}
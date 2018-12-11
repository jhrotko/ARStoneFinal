using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class GameManager : MonoBehaviour {
    public List<GameObject> PossibleMonsters;
    public PlayerManager player;
    private List<PlayerMonster> playerHand = new List<PlayerMonster>();
    
    public TextMesh Title;
  
    public Boss dragonBoss;
	
	private float timer;
    private bool gameFinished = false;
	public bool PlayerTurn;

    public ReticleTest reticle;
	
	// Use this for initialization
	void Start () {
		Title.text = "Starting Game";
		PlayerTurn = true;

	}
	
	// Update is called once per frame
	void Update () {
        foreach (PlayerMonster creature in playerHand)
        {

            if (creature.GetLife() <= 0)
            {
                playerHand.Remove(creature);
                player.DecreaseLife(creature.GetTotalLife());

            }
        }
        if (!gameFinished)
        {
            timer += Time.deltaTime;
            PlayerTurn = !GameObject.Find("Reticle").GetComponent<ReticleTest>().getTurn();

            UpdateCardList();

            if (timer >= 2.0f)
            {
                Title.text = "";
                timer = 0.0f;
            }
            //Debug.Log("Player Life " + player.GetLife());
            if (player.GetLife() <= 0)
            {
                Title.text = "Game Over";
                gameFinished = true;
            }

            if (dragonBoss.life <= 0)
            {
                Title.text = "YOU WON!!!";
                gameFinished = true;
            }

            if (PlayerTurn)
            {
                //Debug.Log("Player Turn");
               
            }
            else
            {
                Debug.Log("ENEMY TURN");
               

                //Set default to Defend
                SaveTurn();

                //Boss Attacks!
                dragonBoss.BossTurn(playerHand);
                if (playerHand.Count == 0) { 
                    player.DecreaseLife(5);
                }

                //Reset Board

                reticle.reset(PossibleMonsters);

                //If some mosnter dies, player's life decreases the mosnter health

                PlayerTurn = true;
            }
        }

	}

    private void UpdateCardList()
    {
        // Get the Vuforia StateManager
        StateManager sm = TrackerManager.Instance.GetStateManager();

        // Query the StateManager to retrieve the list of
        // currently 'active' trackables 
        //(i.e. the ones currently being tracked by Vuforia)
        IEnumerable<TrackableBehaviour> activeTrackables = sm.GetActiveTrackableBehaviours();

        // Iterate through the list of active trackables
        foreach (TrackableBehaviour tb in activeTrackables)
        {
            string type = tb.TrackableName.Substring(0, 12);

            if (type == "CreatureType")
            {
                string CreatureName = tb.TrackableName.Substring(13, tb.TrackableName.Length - 13);

                PlayerMonster creature = FindCreature(CreatureName);

                if(creature != null && !playerHand.Contains(creature) && creature.GetLife() > 0)
                {
                    playerHand.Add(creature);
                    Debug.Log("ADDED TO PLAYERHAND --> " + CreatureName);
                }
            }
            
        }
    }

    public PlayerMonster FindCreature(string creatureName)
    {
        foreach(GameObject monster in PossibleMonsters)
        {
            
            if (monster.name == creatureName)
            {
                return monster.GetComponent<PlayerMonster>();
            }
                
        }
        return null;
    }

    private void SaveTurn()
    {
        foreach (PlayerMonster monster in playerHand)
        {
            
            if (!monster.GetAttacking())
            {
                //Default is Defend
                monster.Defending(true);
            }

            monster.PlayAnimation();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour //this script needs to be added to the player component in unity
{
    public LogicScript logic;
    public playerScript player;
   
    void Start()
    {
        //This will look for the first game object in the hierarchy with the tag Logic.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>();
    }

    //coroutine: allows us to write one respawn code for all the collectibles instead of invoking it separately fro each one
    //IEnumerator will let us pass a parameter i.e. a collision/the thing we ran into, to the function


    public void OnTriggerEnter2D(Collider2D other) //called every time the player collides with a trigger collider
    {
        if (other.CompareTag("Collectible"))//if player collides with a collectible
        {
            Collect(other.GetComponent<Collectible>()); 
        }
    }

    private void Collect(Collectible collectible)
    {
        if (collectible.Collect())
        {
            if (collectible is StarCollectible)
            {
                if (player.playerIsAlive)//checks if the player is still alive
                {
                    logic.addScore(5);
                }
                Debug.Log("Star Collected");
                
            }
        }
    }
}

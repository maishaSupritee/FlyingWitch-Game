using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour //this script needs to be added to the player component in unity
{
    public LogicScript logic;
    public playerScript player;
    private System.Random rand = new System.Random(); //instantiate at the top of the class once instead of in a function, to avoid memory leak
    // Start is called before the first frame update
    void Start()
    {
        //This will look for the first game object in the hierarchy with the tag Logic.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>();
    }

    //coroutine: allows us to write one respawn code for all the collectibles instead of invoking it separately fro each one
    //IEnumerator will let us pass a parameter i.e. a collision/the thing we ran into, to the function
    IEnumerator Respawn (Collider2D collision, int time)
    {
        yield return new WaitForSeconds(time); //wait for time, then do code
        collision.GetComponent<Collectible>().isCollected = false; //newly respawned collectible is not collected yet
        collision.gameObject.SetActive(true); //activate the new collectible in the game scene
    }

    public void OnTriggerEnter2D(Collider2D other) //called every time the player collides with a trigger collider
    {
        if (other.CompareTag("Collectible"))//if player collides with a collectible
        {
            Collect(other.GetComponent<Collectible>()); //Collect the collectible
            //respawn after a random time between 4 and 11 seconds
            StartCoroutine(Respawn(other, rand.Next(4,11)));
        }
    }

    private void Collect(Collectible collectible)
    {
        if (collectible.Collect())
        {
            if (collectible is StarCollectible)
            {
                Debug.Log("Star Collected");
                if (player.playerIsAlive)//checks if the player is still alive
                {
                    logic.addScore(5);
                }
            }
        }
    }
}

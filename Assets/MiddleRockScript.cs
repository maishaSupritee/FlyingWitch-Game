using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleRockScript : MonoBehaviour
{
    public LogicScript logic;
    public playerScript player;
    // Start is called before the first frame update
    void Start()
    {
        //This will look for the first game object in the hierarchy with the tag Logic.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //there's also OnTriggerExit or OnTriggerStay functions
    {
        if(collision.gameObject.layer==3 && player.playerIsAlive)//checks if the collision with the trigger happens with a game object in the player layer & if the player is still alive
        {
            logic.addScore(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleRockScript : MonoBehaviour
{
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        //This will look for the first game object in the hierarchy with the tag Logic.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //there's also OnTriggerExit or OnTriggerStay functions
    {
        if(collision.gameObject.layer==3)//checks if the collision with the trigger happens with a game object in the player layer
        {
            logic.addScore(1);
        }
    }
}

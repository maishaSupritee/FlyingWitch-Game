using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flyStrength;
    public LogicScript logic;
    public bool playerIsAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        //This will look for the first game object in the hierarchy with the tag Logic.
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerIsAlive) //if user presses the space key and the player is still alive, make the player fly
        {
            
            myRigidbody.velocity = Vector2.up * flyStrength;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //so when player collides with the hills
    {
        logic.gameOver();
        playerIsAlive = false;
    }
}

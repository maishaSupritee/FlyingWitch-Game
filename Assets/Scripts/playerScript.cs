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
        if (Input.GetKeyDown(KeyCode.Space) && playerIsAlive) //if user presses the space key and the player is still alive, make the player fly
        {

            myRigidbody.velocity = Vector2.up * flyStrength;
        }
        if (transform.position.y > 6 || transform.position.y < (-6))
        {
            logic.gameOver();
            playerIsAlive = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) //so when player collides with the hills
    {

        if(PotionManager.potions <= 0 )
        {
            logic.gameOver();
            playerIsAlive = false;
        }
        else
        {
            PotionManager.potions--;
            StartCoroutine(UsePotion());
        }
    
    }

    IEnumerator UsePotion()
    {
        Physics2D.IgnoreLayerCollision(3, 6); //player is layer 3 and rock is layer 6
        yield return new WaitForSeconds(0); //witch invincible for 3 seconds
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
}

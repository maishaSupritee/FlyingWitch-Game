using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpawn : MonoBehaviour
{
    public GameObject potion;
    public float timer = 0;
    public float heightOffset = 2;
    // Start is called before the first frame update
    private System.Random rand = new System.Random(); //instantiate at the top of the class once instead of in a function, to avoid memory leak

    void Start()
    {

    }
    void Update()
    {

        float spawnRate = rand.Next(20, 30);
        if (timer < spawnRate)
        {
            timer += Time.deltaTime; //creates a number that counts up every frame 
                                     //and works the same no matter what our computer frame rate is
        }
        else
        {
            //spawn a potion if the timer has reached the spawnRate
            spawnPotion();
            timer = 0; //reset the timer again
        }
    }
    void spawnPotion()
    {
        float lowestPosition = transform.position.y - heightOffset;
        float highestPosition = transform.position.y + heightOffset;
        Instantiate(potion, new Vector3(transform.position.x, Random.Range(lowestPosition, highestPosition), 0), transform.rotation);
        Debug.Log("Potion created");
    }

}



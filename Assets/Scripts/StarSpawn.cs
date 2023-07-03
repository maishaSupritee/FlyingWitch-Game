using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawn : MonoBehaviour
{
    public GameObject star;
    public float timer = 0;
    public float heightOffset = 2;
    // Start is called before the first frame update
    private System.Random rand = new System.Random(); //instantiate at the top of the class once instead of in a function, to avoid memory leak

    void Start()
    {
        spawnStar();
        
    }
    void Update()
    {
        float spawnRate = rand.Next(4,8); //spawn star after any time between 4 - 8 seconds
        if(timer<spawnRate) 
        {
            timer += Time.deltaTime; //creates a number that counts up every frame 
                                    //and works the same no matter what our computer frame rate is
        }
        else
        {
            //spawn a star if the timer has reached the spawnRate
            spawnStar(); 
            timer = 0; //reset the timer again
        }
    }
    void spawnStar()
    {
        float lowestPosition = transform.position.y - heightOffset;
        float highestPosition = transform.position.y + heightOffset;
        Instantiate(star, new Vector3(transform.position.x, Random.Range(lowestPosition, highestPosition), 0), transform.rotation);
        Debug.Log("Star created");
    }
    /*IEnumerator Respawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        float lowestPosition = transform.position.y - heightOffset;
        float highestPosition = transform.position.y + heightOffset;
        // Code to execute after the delay
        Instantiate(star, new Vector3(transform.position.x, Random.Range(lowestPosition, highestPosition), 0), transform.rotation);
        Debug.Log("Star created");
    }*/
}

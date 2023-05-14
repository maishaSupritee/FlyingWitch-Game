using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawnScript : MonoBehaviour
{
    public GameObject rock;
    public float spawnRate = 2; //how many seconds it should be between spawns
    private float timer = 0; // a timer will count up for a specified number of seconds
                            //  run some code and then start the count again
    public float heightOffset = 4;
    // Start is called before the first frame update
    void Start()
    {
        spawnRock();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<spawnRate)
        {
            timer += Time.deltaTime; //creates a number that counts up every frame 
                                    //and works the same no matter what our computer frame rate is
        }
        else
        {
            //spawn a hill if the timer has reached the spawnRate
            spawnRock(); 
            timer = 0; //reset the timer again
        }
    }
    void spawnRock()
    {
        float lowestPosition = transform.position.y - heightOffset;
        float highestPosition = transform.position.y + heightOffset;

        Instantiate(rock, new Vector3(transform.position.x, Random.Range(lowestPosition, highestPosition), 0), transform.rotation); 
    }
}

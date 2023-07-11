using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float moveSpeed = 5; // the value here is the default speed which we can change in unity
    public float deleteZone = -14;
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; 
        // we want to add to its current position thats why we are adding its initial position first
        // and make it move at the moveSpeed
        if(transform.position.x < deleteZone)
        {
            Debug.Log("Collectible deleted.");  
            Destroy(gameObject); //if it moves past the deleteZone value, 
                                //destroy the game object that holds this script
        }
    }
    public bool isCollected = false;
    public bool Collect()
    {
        if(isCollected)
            return false; //already collected item
        isCollected = true; //hadn't been previously collected, so now collect
        gameObject.SetActive(false); //deactivate the collectible so its not shown in scene anymore
        return true;
    }
    

    
}

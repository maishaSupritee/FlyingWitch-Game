using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hillMoveScript : MonoBehaviour
{
    public float moveSpeed = 5; // the value here is the default speed which we can change in unity
    public float deleteZone = -14;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime; 
        // we want to add to its current position thats why we are adding its initial position first
        // and make it move at the moveSpeed
        if(transform.position.x < deleteZone)
        {
            Debug.Log("Hill deleted.");  //adds the hill deleted message
                                        //to our console window in unity whenever a hill is deleted
            Destroy(gameObject); //if it moves past the deletZone value, 
                                //destroy the game object that holds this script
        }
    }
}

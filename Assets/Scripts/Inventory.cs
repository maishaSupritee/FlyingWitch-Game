using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour //this script needs to be added to the player component in unity
{
    public void OnTriggerEnter2D(Collider2D other) //called every time the player collides with a trigger collider
    {
        if (other.CompareTag("Collectible"))//if player collides with a collectible
        {
            Collect(other.GetComponent<Collectible>()); //Collect the collectible
        }
    }

    private void Collect (Collectible collectible)
    {
        if(collectible.Collect())
        {
            if(collectible is StarCollectible)
            {
                Debug.Log("Star Collected");
            }
        }
    }
}

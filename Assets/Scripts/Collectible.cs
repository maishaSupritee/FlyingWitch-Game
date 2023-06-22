using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public bool isCollected = false;
    public bool Collect()
    {
        if(isCollected)
            return false; //already collected item

        isCollected = true; //hadn't been previously collected, so now collect
        Destroy(gameObject); //item collected so destroy the item in game
        return true;
    }
}

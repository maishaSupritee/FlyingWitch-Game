using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : MonoBehaviour
{
    public static int potions = 0; //can collect at max 3 potions

    public Image[] potionImages;
    public Sprite emptyPotion;
    public Sprite fullPotion;

    void Awake()
    {
        potions = 0;
    }
    void Update()
    {
        foreach (Image img in potionImages)
        {
            img.sprite = emptyPotion;
        }

        for (int i = 0; i < potions; i++)
        {
            potionImages[i].sprite = fullPotion;
        }
    }
}
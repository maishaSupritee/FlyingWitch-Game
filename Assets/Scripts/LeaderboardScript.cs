using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardScript : MonoBehaviour
{
    [SerializeField] private Transform container; 
    [SerializeField] private Transform entry;
    private int height = 80; //height of each individual entry
    private int offset = 390; //y position of first entry
    private void Awake()
    {
        entry.gameObject.SetActive(false); //disabling the game object so it doesn't show on screen
        for (int i=0; i<10; i++)
        {
            Transform entryTransform = Instantiate(entry, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>(); // it  will just get the Rect Transform component of our entryTransforms in Unity and put them in this variable
            //we are using Vector 2 so we only need to put x and y values, no z value needed.
            entryRectTransform.anchoredPosition = new Vector2(0, (-height * i) + offset );//negative because we want them to appear moving downwards     
            entryTransform.gameObject.SetActive(true);
            
            //manually populating the entries
         /*    entryTransform.Find("RankText").GetComponent<TextMeshProUGUI>().text = "2nd";
            entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = "Maisha";
            entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "2000"; */

            
        }
    }
}

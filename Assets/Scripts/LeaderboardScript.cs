using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardScript : MonoBehaviour
{
    [SerializeField] private Transform container; 
    [SerializeField] private Transform entry;
    private int height = 390;
    private int offset = 80;
    private void Awake()
    {
        entry.gameObject.SetActive(false); //disabling the game object so it doesn't show on screen
        for (int i=0; i<10; i++)
        {
            Transform entryTransform = Instantiate(entry, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>(); // it  will just get the Rect Transform component of our entryTransforms in Unity and put them in this variable
            if(i==0)
            {
                //we are using Vector 2 so we only need to put x and y values, no z value needed.
                entryRectTransform.anchoredPosition = new Vector2(0, height);        
                entryTransform.gameObject.SetActive(true);
            }
            else
            {
                entryRectTransform.anchoredPosition = new Vector2(0, height - (offset * i));        
                entryTransform.gameObject.SetActive(true);
            }
        }
    }
}

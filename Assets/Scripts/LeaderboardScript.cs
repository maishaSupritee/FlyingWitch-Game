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

    private List<HighScoreElement> highScoreElements;
    private List<Transform> highScoreEntriesTransformList;
    private void Awake()
    {
        entry.gameObject.SetActive(false); //disabling the game object so it doesn't show on screen
        highScoreElements = FileHandler.ReadListFromJSON<HighScoreElement>("highscores.json");

        for (int i = 0; i < highScoreElements.Count; i++) //sorting the highscores
        {
            for (int j = i + 1; j < highScoreElements.Count; j++)
            {
                if (highScoreElements[i].score < highScoreElements[j].score)
                {
                    HighScoreElement temp = highScoreElements[i];
                    highScoreElements[i] = highScoreElements[j];
                    highScoreElements[j] = temp;
                }
            }
        }

        highScoreEntriesTransformList = new List<Transform>();
        foreach (HighScoreElement highScoreElement in highScoreElements)
        {
            CreateHighScoreEntryTransform(highScoreElement, container, highScoreEntriesTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreElement highScore, Transform container, List<Transform> entryList)
    {

        Transform entryTransform = Instantiate(entry, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>(); // it  will just get the Rect Transform component of our entryTransforms in Unity and put them in this variable
        //we are using Vector 2 so we only need to put x and y values, no z value needed.
        entryRectTransform.anchoredPosition = new Vector2(0, (-height * entryList.Count) + offset);//negative because we want them to appear moving downwards     
        entryTransform.gameObject.SetActive(true);

        int rank = entryList.Count + 1;
        string rankText;
        switch (rank)
        {
            default:
                rankText = rank + "th";
                break;
            case 1:
                rankText = "1st";
                break;
            case 2:
                rankText = "2nd";
                break;
            case 3:
                rankText = "3rd";
                break;
        }

        entryTransform.Find("RankText").GetComponent<TextMeshProUGUI>().text = rankText;
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = highScore.playerName;
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = highScore.score.ToString();

        entryList.Add(entryTransform);
    }
}
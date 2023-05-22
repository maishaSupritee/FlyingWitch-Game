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

    private List<HighScoreEntry> highScoreEntries;
    private List<Transform> highScoreEntriesTransformList;
    private void Awake()
    {
        entry.gameObject.SetActive(false); //disabling the game object so it doesn't show on screen
        
        //putting dummy highscore values in our leaderboard
        highScoreEntries = new List<HighScoreEntry>()
        {
            new HighScoreEntry {name = "Jenny", score = 1000},
            new HighScoreEntry {name = "John", score = 500},
            new HighScoreEntry {name = "Jacky", score = 400},
            new HighScoreEntry {name = "Zee", score = 1500},
            new HighScoreEntry {name = "Zack", score = 600},
            new HighScoreEntry {name = "Mary", score = 600},
            new HighScoreEntry {name = "Amy", score = 1470},
            new HighScoreEntry {name = "Trishia", score = 850},
            new HighScoreEntry {name = "Lauren", score = 300},
            new HighScoreEntry {name = "Jason", score = 2000}
        };

        for(int i=0; i<highScoreEntries.Count; i++) //use a better sorting method in the future
        {
            for (int j = i+1; j<highScoreEntries.Count; j++)
            {
                if(highScoreEntries[i].score < highScoreEntries[j].score)
                {
                    HighScoreEntry temp = highScoreEntries[i];
                    highScoreEntries[i] = highScoreEntries[j];
                    highScoreEntries[j] = temp;
                }
            }
        }

        highScoreEntriesTransformList = new List<Transform>();
        foreach(HighScoreEntry highScoreEntry in highScoreEntries)
        {
            CreateHighScoreEntryTransform(highScoreEntry, container, highScoreEntriesTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScore, Transform container, List<Transform> entryList)
    {
            
        Transform entryTransform = Instantiate(entry, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>(); // it  will just get the Rect Transform component of our entryTransforms in Unity and put them in this variable
        //we are using Vector 2 so we only need to put x and y values, no z value needed.
        entryRectTransform.anchoredPosition = new Vector2(0, (-height * entryList.Count) + offset );//negative because we want them to appear moving downwards     
        entryTransform.gameObject.SetActive(true);
            
        int rank = entryList.Count + 1;
        string rankText;
        switch(rank)
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
        entryTransform.Find("NameText").GetComponent<TextMeshProUGUI>().text = highScore.name;
        entryTransform.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = highScore.score.ToString();

        entryList.Add(entryTransform); 
    }

}

 public class HighScoreEntry
    {
        public string name;
        public int score;
    }
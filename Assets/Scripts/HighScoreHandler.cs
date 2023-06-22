using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreHandler : MonoBehaviour
{
    private List<HighScoreElement> highscoreList = new List<HighScoreElement>();
    [SerializeField] int maxCount = 10; //max number of score entries we want
    [HideInInspector] 
    public static string filename = "highscores.json"; //the file in which we will save the scores
    void Start()
    {
        LoadHighScores();
        
    }
    private void LoadHighScores()
    {
        highscoreList = FileHandler.ReadListFromJSON<HighScoreElement>(filename);

        //what if the file contains more entries than we want
        while (highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }
    }

    private void SaveHighScores()
    {
        FileHandler.SaveToJSON<HighScoreElement>(highscoreList, filename);
    }

    public void AddHighScore(HighScoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            //if highScoreList is empty, or if our high score is greater than the highscore in the list, we add high score to it 
            if (i >= highscoreList.Count || element.score > highscoreList[i].score)
            {
                highscoreList.Insert(i, element); //everything with an index higher than i slides back by 1
                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                SaveHighScores();

                break; //every entry below the current one will have lower points and will trigger the for loop 
                        //but if we have already added it to the list, we dont need to go through the list anymore so we use break
            }

        }
    }
}

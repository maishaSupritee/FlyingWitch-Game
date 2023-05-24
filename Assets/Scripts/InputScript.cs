using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InputScript : MonoBehaviour
{
    public LogicScript logic;
    [SerializeField] private Button saveButton;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] HighScoreHandler highScoreHandler;
    public void Save()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        //Get name from input
        string playerName = nameInputField.text;
        int highScore = logic.playerScore;
        Debug.Log($"Name: {playerName}, Score: {highScore}"); //checking if it's working with a debug message

        //Save the name into json
        HighScoreElement entry = new HighScoreElement(playerName, highScore);
        highScoreHandler.AddHighScore(entry);
    }

    public void saveToLeaderboard() // public so we can reference it as a function in an on-click event
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Game has build index = 1, and Leaderboard has build index = 2
    }
}

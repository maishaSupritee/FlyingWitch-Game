using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InputScript : MonoBehaviour
{
    [SerializeField] private Button saveButton;
    [SerializeField] private TMP_InputField nameInputField;

    public void Save()
    {
        //Get name from input
        string name = nameInputField.text;
        Debug.Log(name); //checking if it's working with a debug message

        //Save the name into json
    }

    public void saveToLeaderboard() // public so we can reference it as a function in an on-click event
    {
        SceneManager.LoadScene("Leaderboard");
    }
}

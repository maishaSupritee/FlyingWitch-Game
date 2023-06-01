using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene("Game"); //if we want to go to the scene by its name
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +  1); //getting the game scene with numbers
                                                                        //Our main menu is on 0 in our build settings and our game scene is on 1 in our build settings
    }
    public void Quit()
    {
        Application.Quit(); //closing the application
        Debug.Log("Player has Quit the Game"); // to check it works properly
    }

    public void LeaderBoard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
}

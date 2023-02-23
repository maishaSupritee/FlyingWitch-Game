using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    [ContextMenu("Increase Score")] //allows us to run this function from Unity itself
    public void addScore(int scoreToAdd) //public function as we want to run this function from other scripts
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //this is looking for the name of a scene so our file name 
                                                                    //but as we want the current scene we can just use GetActiveScene().naqme
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    public bool Paused = false; //not paused by default
    public GameObject PauseMenuCanvas; //reference to use our game object in the script
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f; //making sure it's running and not frozen when we load into the game
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)//if game is paused pressing escape key resumes the game
            {
                Play();
            }
            else //if game is running pressing escape key pauses the game
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        PauseMenuCanvas.SetActive(true); // displaying our pause menu screen
        Time.timeScale = 0f; //freeze time with time scale
        Paused = true;

    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false); // stop displaying the pause menu screen
        Time.timeScale = 1f; //defreezes time
        Paused = false;
    }

    public void mainMenuButton() // public so we can reference it as a function in an on-click event
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // current scene is the game scene which has build index of 1, 
                                                                            //our main menu is on buildindex = 0, so we are just subtracting 1 from current scene to get to the main menu screen
    }
}

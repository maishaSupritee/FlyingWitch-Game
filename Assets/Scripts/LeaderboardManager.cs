using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardManager : MonoBehaviour
{
  public void back()
  {
     SceneManager.LoadScene("MainMenu"); 
  }
}

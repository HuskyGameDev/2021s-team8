using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStart()
        {
            SceneManager.LoadScene("River"); //Loads the scene based off of button input
        }

    public void GameQuit()
        {
                Application.Quit(); //quits the game
        }
}

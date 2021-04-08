using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStart()
        {
        StartCoroutine(DelayedStart());
        }

    public void GameQuit()
        {
                Application.Quit(); //quits the game
        }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("River"); //Loads the scene based off of button input
    }
}

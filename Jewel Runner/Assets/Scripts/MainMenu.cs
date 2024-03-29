﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GameStart()
        {
        StartCoroutine(DelayedStart());
        }

     public void GameOptions()
            {
                   StartCoroutine(Controls());
            }

    public void GameQuit()
        {
                Application.Quit(); //quits the game
        }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(2.8f);
        SceneManager.LoadScene("Johnathan"); //Loads the scene based off of button input
    }
    IEnumerator Controls()
        {
            yield return new WaitForSeconds(0.1f);
           SceneManager.LoadScene("Controls"); //Loads the scene based off of button input
        }
}

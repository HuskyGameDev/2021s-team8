﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject pauseMenu;




    // Update is called once per frame
    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }


        void Start ()
            {
                pauseMenu.SetActive(false);
            }

        void Resume()
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            Paused = false;
        }

        void Pause()
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Paused = true;
        }
    }
}

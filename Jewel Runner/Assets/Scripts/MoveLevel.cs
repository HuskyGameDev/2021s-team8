using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveLevel : MonoBehaviour
{
    public string sceneName;
    public GameObject player;       //player
    private bool door = false;     //checks if we are touching the door

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            door = true;       //checks if player is touching door
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door = false;      // checks if player is touching door
    }

    IEnumerator DelayedStart()
        {
            yield return new WaitForSeconds(.01f);
            SceneManager.LoadScene(sceneName); //Loads the scene based off of button input
        }

    void Update()
    {
        if (door)
        {
            StartCoroutine(DelayedStart());                 // sets new level
            door = false;     // checks if player is touching door
        }
    }
}

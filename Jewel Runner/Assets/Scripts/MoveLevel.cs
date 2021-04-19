using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MoveLevel : MonoBehaviour
{
    public GameObject player;       //player
    private bool door = false;     //checks if we are touching the door

    void OnTriggerEnter2D(Collider2D collision)
    {
        door = true;       //checks if player is touching door
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        door = false;      // checks if player is touching door
    }

    IEnumerator DelayedStart()
        {
            yield return new WaitForSeconds(.01f);
            SceneManager.LoadScene("Simone"); //Loads the scene based off of button input
        }

    void Update()
    {
        // loads new level if e is pressed and touching door
        if (Input.GetKeyDown(KeyCode.E) && door)
        {
            DelayedStart();                 // sets new level
            door = false;     // checks if player is touching door
        }
    }
}

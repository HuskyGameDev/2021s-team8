using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This program allows for sound to be played everytime the player uses or interacts with a jewel.
 * Inputs: BlackJewel audio source, BlueJewel audio source, GreenJewel audio source, and RedJewel audio source.
 * 
 * How to use this:
 * Drag and drop this script on to every jewel in a level.
 * Create four different audio sources in the scene.
 * Drag and drop the correct audio file from the SFX folder into the audio clip of the audio source.
 * Supply the input of the corresponding audio source with the same colored jewel. 
 */


public class SFXPlaying : MonoBehaviour
{
    // Creating the audio sources (one for each jewel color)
    public AudioSource BlackJewel;
    public AudioSource BlueJewel;
    public AudioSource GreenJewel;
    public AudioSource RedJewel;

    // Creating methods for the sounds of the jewels to be played with each corresponding color
    public void PlayBlackJewel()
    {
        BlackJewel.Play();
    }
    public void PlayBlueJewel()
    {
        BlueJewel.Play();
    }
    public void PlayGreenJewel()
    {
        GreenJewel.Play();
    }
    public void PlayRedJewel()
    {
        RedJewel.Play();
    }

    private bool touchingJewel = false;     // Determines if we're touching the jewel 

    void OnTriggerEnter2D(Collider2D collision)
    {
        touchingJewel = true;       // If the player collides with the jewel this will set the bool to true
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingJewel = false;      // Once the player is no longer touching the jewel, sets the bool to false
    }

    void Update()
    {
        // if the E key is pressed AND the player is touching the jewel
        if (Input.GetKeyDown(KeyCode.E) && touchingJewel)
        {
            // This list of if statements makes sure the right sound gets played for the same colored jewel
            if (BlackJewel != null)
            {
                PlayBlackJewel();
            } else if (GreenJewel != null)
            {
                PlayGreenJewel();
            } else if (BlueJewel != null)
            {
                PlayBlueJewel();
            } else if (RedJewel != null)
            {
                PlayRedJewel();
            }
        }
    }
}
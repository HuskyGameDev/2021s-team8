using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This program will allow an object to disappear after it gets interacted with once.
 * Inputs: Two different jewel objects - Jewel, Jewel2
 *
 * How to use this: 
 * Drag and drop this script onto both the starting jewel and the other jewel that the player gets teleported to. 
 * Supply the inputs of the starting jewel and the ending jewel by dragging into the correct spots.
 */

public class Disappearance : MonoBehaviour
{
    public GameObject jewel;    //The jewel object
    public GameObject jewel2;   //The other jewel object
    private bool touchingJewel = false;     // Determines if we're touching the jewel

    void OnTriggerEnter2D(Collider2D collision)
    {
        touchingJewel = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingJewel = false;
    }

    void Update()
    {

        /* If the E key is pressed AND the player is touching the jewel,
         * then the jewels will be deactivated so that the player can no
         * longer interact with the jewel, abstracting the idea that the
         * jewel is breaking.
         */
        if (Input.GetKeyDown(KeyCode.E) && touchingJewel)
        {
            jewel.SetActive(false);
            jewel2.SetActive(false);
        }
    }
}

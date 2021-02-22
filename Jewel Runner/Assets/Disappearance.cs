using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This program will allow an object to disappear after it gets interacted with once.
 * Inputs: Two different jewel objects - Jewel, Jewel2
 *
 * How to use this: 
 * Drag and drop this script onto both the starting jewel and the other jewel that the player gets teleported to. 
 * Supply the inputs of the starting jewel and the ending jewel by dragging into the corect spots.
 */


public class Disappearance : MonoBehaviour
{
    public GameObject jewel;    //The jewel object
    public GameObject jewel2;   //The other jewel object


    /*This method uses a trigger event to know when the specific object (or jewel) gets collided with.
     * 
     * Once the player touches the jewel and teleports, both jewels - the orginal and one teleported to -
     * will be set to be deactivated, meaning they will disappear from the screen and not be able to be 
     * used again by the player.
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
        jewel.SetActive(false);
        jewel2.SetActive(false);
    }
}

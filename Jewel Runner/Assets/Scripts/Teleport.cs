using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This program allows the player to collide with an object and teleport to a new location.
 * Inputs: Player, Target Jewel
 * 
 * How to use this:
 * Drag and drop this script on to the starting jewel. 
 * Supply the inputs of the player and the ending jewel by dragging into the corect spots.
 * Make sure that both jewels have Box Collider 2D on them.
 * On the starting jewel, make sure the Box Collider 2d has "Is Trigger" checked.
 * 
 * Updates:
 *      - added when the E key is pressed you teleport. 
 */


public class Teleport : MonoBehaviour
{
    public Transform targetJewel;   // The jewel we are teleporting to
    public GameObject player;       // The character object
    private bool touchingJewel = false;     // Determines if we're touching the jewel
    public bool delayTeleport = false;

    void OnTriggerEnter2D(Collider2D collision)
    {   
        touchingJewel = true;       // If the player collides with the jewel this will set the bool to true
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingJewel = false;      // Once the player is no longer touching the jewel, sets the bool to false
    }

    void teleport()
    {
        /* This pretty much means that the player's position will become the target jewel's 
         * position + 0.5 (otherwise the player just lands right in the object and cannot
         * move). 
         * The important thing to remember about this is that any object's position is a 
         * Vector3 with x, y, and z traits. The structure Vector3 can only take floating
         * point numbers (e.g. not doubles) so you must add 'f' after decimal values.
         */
        player.transform.position = targetJewel.transform.position + new Vector3(0.5f, 0, 0);
         SetMyBoolToFalse();
    }

  IEnumerator SetMyBoolToFalse()
   {

      yield return new WaitForSeconds(3f);
      delayTeleport = false;
      yield return null;
 }

    void Update()
    {
        // if player is touching the jewel
        if (touchingJewel && delayTeleport == false)
        {
            delayTeleport = true;
            teleport();                 // teleports the player
            touchingJewel = false;      // sets back to false or else it will continue thinking we're touching a jewel
        }
    }
}

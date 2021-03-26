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
 * 
 */


public class Teleport : MonoBehaviour
{
    public Transform targetJewel;   // The jewel we are teleporting to
    public GameObject player;       // The character object

    void OnTriggerEnter2D(Collider2D collision)
    {
        /* This pretty much means that the player's position will become the target jewel's 
         * position + 0.5 (otherwise the player just lands right in the object and cannot
         * move). 
         * The important thing to remember about this is that any object's position is a 
         * Vector3 with x, y, and z traits. The structure Vector3 can only take floating
         * point numbers (e.g. not doubles) so you must add 'f' after decimal values.
         */
        player.transform.position = targetJewel.transform.position + new Vector3(0.5f, 0, 0);
    }
}

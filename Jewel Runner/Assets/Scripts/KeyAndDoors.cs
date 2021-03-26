using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This program will allow an object to disappear after it gets interacted with once.
 * Inputs: A key, locked door, and unlocked door object - Key, Locked, Unlocked
 *
 * How to use this: 
 * Drag and drop this script onto the key object. 
 * Supply the inputs of the key, locked door, and unlocked door by dragging into the correct spots.
 */


public class KeyAndDoors : MonoBehaviour
{
    public GameObject key; //The key object
    public GameObject locked; //The locked door object
    public GameObject unlocked; //The unlocked door object


    /*Start is called before the first frame update.
     * 
     * This is used to make the unlocked door object disappear before the game loads in, making it invisible to the player.
     */
    void Start()
    {
        unlocked.SetActive(false);
    }


    /*This method uses a trigger event to know when the specific object (or key) gets collided with.
     * 
     * Once the player touches the key, both the key and the locked door objects will be set to be deactivated,
     * meaning they will disappear from the screen and not be able to be interacted with again by the player.
     * The unlocked door object will then be activated, allowing the player to see that they have unlocked the door.
     */
    void OnTriggerEnter2D(Collider2D collision)
    {
        key.SetActive(false);
        locked.SetActive(false);
        unlocked.SetActive(true);
    }
}

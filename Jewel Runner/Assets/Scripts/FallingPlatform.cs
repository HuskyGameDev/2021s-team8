using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponents<BoxCollider2D>()[0].enabled = true;
        GetComponents<BoxCollider2D>()[1].enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("Break", 0.5f); //breaks the platform after half a second of the player standing on it
    }

    private void Break() //disables the sprite renderer and both box colliders to ensure the gameobject no longer interacts with the player
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponents<BoxCollider2D>()[0].enabled = false;
        GetComponents<BoxCollider2D>()[1].enabled = false;
    }
}

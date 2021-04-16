using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehavior : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer; //the pressure plate's sprite renderer
    private BoxCollider2D BoxCollider2D; //the pressure plate's box collider
    private bool IsPressed; //whether or not the pressure plate has been pressed

    void Start() //initializes values
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        IsPressed = false;
    }

    private void OnTriggerEnter2D(Collider2D other) //when the player steps on the pressure plate, the pressure plate disapears and becomes pressed
    {
        if(other.tag == "Player")
        {
            IsPressed = true;
            SpriteRenderer.enabled = false;
            BoxCollider2D.enabled = false;
        }
    }

    public bool GetIsPressed()
    {
        return IsPressed;
    }
}

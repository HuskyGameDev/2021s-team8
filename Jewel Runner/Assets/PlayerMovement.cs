using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script allows the player to be moved when buttons are pressed.
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    public float charSpeed = 40f;       // character speed
    float walkSpeed = 0.0f;             // walking speed
    bool jump = false;                  // is the player jumping?

    // Update is called once per frame
    void Update()
    {
        // the inputs such as "Horizontal" are decided at edit<project settings<input manager  

        walkSpeed = Input.GetAxisRaw("Horizontal")*charSpeed;  // takes an input (a, d) to move by our determined speed.

        animator.SetFloat("Speed", Mathf.Abs(walkSpeed));

        if(Input.GetButtonDown("Jump")) // takes w as the input
        {
            jump = true;                // when w is pressed it is true you are jumping
            animator.SetBool("IsJumping", true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(walkSpeed * Time.fixedDeltaTime, jump);     // updates player from the character controller script we created
        jump = false;                   // this stops us from infinitely jumping.
    }
}

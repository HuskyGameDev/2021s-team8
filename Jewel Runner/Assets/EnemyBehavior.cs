using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemyFOV fieldOfView; //the fov script for this specific enemy
    [SerializeField] private GameObject respawnPosition; //the respawn position for this specific enemy
    [SerializeField] private float moveSpeed = 1f; //movement speed of the enemy

    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;

    private bool lookingRight = false; //determines the direction the enemy is facing

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (lookingRight) //moves the enemy in the direction it's looking by the movementspeed, also sets the direction of the fov
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            fieldOfView.setDirection(fieldOfView.getFOV() / 2f);

        } else {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            fieldOfView.setDirection(fieldOfView.getFOV() / 2f + 180f);
        }
        fieldOfView.setOrigin(this.transform.position);
    }

    private void OnTriggerExit2D(Collider2D collision) //when the collider loses connection with the ground, the enemy will turn around
    {
        if (collision.CompareTag("Ground"))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z); //flips enemy to face other direction
            lookingRight = !lookingRight; //changes looking right to be the opposite
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) //when the collider hits a wall or spike, the enemy will turn around
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Spikes"))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lookingRight = !lookingRight;
        }
    }

    /* gets a the transform of the respawn GameObject
     * 
     * return: the transform of the respawn GameObject
     */
    private Transform getRespawn()
    {
        return respawnPosition.transform;
    }
}

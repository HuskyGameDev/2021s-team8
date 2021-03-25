using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private EnemyFOV fieldOfView; //the fov script for this specific enemy
    [SerializeField] private GameObject respawnPosition; //the respawn position for this specific enemy
    [SerializeField] private float moveSpeed = 1f; //movement speed of the enemy
    [SerializeField] private GameObject player; // 
    private Vector2 aimDirection;

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
            aimDirection = new Vector2(10, 0);

        } else {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            fieldOfView.setDirection(fieldOfView.getFOV() / 2f + 180f);
            aimDirection = new Vector2(-10, 0);
        }
        fieldOfView.setOrigin(this.transform.position);

        findPlayer();
    }

    private void findPlayer()
    {
        Vector2 myPosition = new Vector2(this.transform.position.x, this.transform.position.y); //creates a Vector2 containing the x and y positions of the enemy
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y); //creates a Vector2 containing the x and y positions of the player
        if (Vector2.Distance(myPosition, playerPosition) < fieldOfView.getViewDistance()) //if the player is inside of the view distance
        {
            Vector2 dirToPlayer = (playerPosition - myPosition).normalized;
            if (Vector2.Angle(aimDirection,dirToPlayer) < fieldOfView.getFOV() / 2f) //if player is inside field of view
            {
                RaycastHit2D raycast = Physics2D.Raycast(myPosition, dirToPlayer, fieldOfView.getViewDistance());
                if (raycast.collider != null)
                {
                    if (raycast.collider.CompareTag("Player"))
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                }
            }
        }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatBehavior : MonoBehaviour
{
    [SerializeField] private GameObject respawnPosition; // Respawn position for bat
    [SerializeField] private float moveSpeed = 1f; // Horizontal Movement speed of the bat
    [SerializeField] private float vMoveSpeed = 1f; // Vertical Movement speed of the bat

    [SerializeField] private GameObject player; // 
    private Vector2 aimDirection;

    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;

    private bool lookingRight = false; // Bool for checking direction bat is facing
    private bool goingUp = false;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (lookingRight && goingUp) // Moves bat right and up
        {
            myRigidbody.velocity = new Vector2(moveSpeed, vMoveSpeed);
            aimDirection = new Vector2(10, 0);

        }
        else if (lookingRight && !goingUp)// Moves bat left
        {
            myRigidbody.velocity = new Vector2(moveSpeed, -vMoveSpeed);
            aimDirection = new Vector2(10, 0);
        }
        else if (!lookingRight && goingUp) 
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, vMoveSpeed);
            aimDirection = new Vector2(-10, 0);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, -vMoveSpeed);
            aimDirection = new Vector2(-10, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Whenever colliders hits a wall, the bat turns
    {
        if (collision.CompareTag("Wall")) // If the bat hits a wall (horizontal)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lookingRight = !lookingRight;
        }
        if (collision.CompareTag("Ground")) // If the bat hits the ground (vertical)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            lookingRight = !lookingRight;
            goingUp = !goingUp;
        }
        if (collision.CompareTag("Player")) // If the bat hits the player
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Resets level
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatBehavior : MonoBehaviour
{
    [SerializeField] private GameObject respawnPosition; // Respawn position for bat
    [SerializeField] private float speed = 1f; // Horizontal Movement speed of the bat

    [SerializeField] private GameObject player; // 
    private Vector2 aimDirection;

    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;

    private bool lookingRight = false; // Bool for checking direction bat is facing

    private float thetaStep = Mathf.PI / 32f;
    [SerializeField] private float theta = 0f;
    [SerializeField] private float amplitude = 4f;

    private float xOffset; // k variable for Sine equation
    [SerializeField] private float waveFrequency = 2f;

    [SerializeField] private float oneForHorz = 0;

    private int waveDirection = 1;

    [SerializeField] bool horizontalWave = true;



    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (horizontalWave)
        {
            xOffset = transform.position.x;
            float newXPos = waveDirection * amplitude * Mathf.Sin(theta * waveFrequency) + xOffset;
            float xStep = newXPos - transform.position.x;

            if (lookingRight == false && oneForHorz != 1)
            {
                transform.Translate(new Vector3(xStep, speed * Time.deltaTime));
            }
            else if (lookingRight == true && oneForHorz != 1)
            {
                transform.Translate(new Vector3(xStep, -1 * (speed * Time.deltaTime)));
            }
            else if (lookingRight == false && oneForHorz == 1)
            {
                transform.Translate(new Vector3((speed * Time.deltaTime), xStep));
            }
            else
            {
                transform.Translate(new Vector3(-1 * (speed * Time.deltaTime), xStep));

            }
            theta += thetaStep;
        } else
        {
            transform.Translate(new Vector2(0, amplitude * Mathf.Sin(theta * waveFrequency)));
            theta += thetaStep;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // Whenever colliders hits a wall, the bat turns
    {
        if (collision.CompareTag("Ground")) // If the bat hits a wall (horizontal)
        {
            lookingRight = !lookingRight;
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

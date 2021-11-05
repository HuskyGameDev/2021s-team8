using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
	// side note: searlizefield can let private variables show up in the editor.
	[SerializeField] private float jumpForce = 400f;                         // Force that is added when the player jumps
	[SerializeField] private LayerMask isGround;							 // A mask that tells what is ground to the player
	[SerializeField] private Transform isGrounded;                          // Checking if the player is on the ground or not
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;

	const float isGroundedOverlap = .001f;				// The overlap amount to determine if the player is grounded
	private bool grounded;								// true or false whether the player is on the ground
	private Rigidbody2D rigidbody2D;
	private bool facingRight = true;					// Determines which way the player is facing
	private Vector3 velocity = Vector3.zero;
    private float dashCooldownTime = 0.25f;
    private float nextDashTime = 0f;
    private bool canDash = true;
    private bool isDashing = false;
    [SerializeField] private bool isJumping = false;

    private float jumpTimeCounter;
    [SerializeField] private float jumpTime;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
        isJumping = false;
        isDashing = false;
	}

	private void FixedUpdate()
	{
		bool wasGrounded = grounded;
		grounded = false;

		// The player is grounded if a circle to the ground is touching any ground material
		Collider2D[] colliders = Physics2D.OverlapCircleAll(isGrounded.position, isGroundedOverlap, isGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				grounded = true;
                canDash = true; //makes sure that when the player is on the ground, their dash is refreshed
				if (!wasGrounded && rigidbody2D.velocity.y < 0)
					OnLandEvent.Invoke();
			}
		}

        // deactivates gravity for .15 seconds after dashing, improves the feel of horizontal dashes
        if (Time.time < nextDashTime - .12f){
            rigidbody2D.gravityScale = 0;
            isDashing = true;
        } else
        {
            isDashing = false;
            rigidbody2D.gravityScale = 3;
        }
	}


	public void Move(float move, bool jump)
	{
        if (!isDashing) //prevents player from moving if they are in the middle of a dash
        {
            //if the player is on the ground
            //if the player is on the ground
            if (grounded)
            {
                // Character moves by a velocity
                Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);
                rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing); // makes for smooth moves

                // if the player is facing left and moving right then
                if (move > 0 && !facingRight)
                {
                    // player sprite flips
                    Flip();
                }
                // if the player is facing right but moving left then
                else if (move < 0 && facingRight)
                {
                    // player sprite flips
                    Flip();
                }
            }
            if (!grounded)
            {
                Vector3 targetVelocity = new Vector2(move * 10f, rigidbody2D.velocity.y);
                rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing); // makes for smooth moves
                if (move > 0 && !facingRight)
                {
                    // player sprite flips
                    Flip();
                }
                // if the player is facing right but moving left then
                else if (move < 0 && facingRight)
                {
                    // player sprite flips
                    Flip();
                }
            }
            // if the player is on the ground and jumps
            if (grounded && jump)
            {
                // Jump force is added to the player
                grounded = false;
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            }

            if (Input.GetKey(KeyCode.Space) && isJumping) //while the space key is down, if the amount of time the player is allowed to jump for hasn't been reached, the player will continue up
            {
                if(jumpTimeCounter > 0)
                {
                    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                } else
                {
                    isJumping = false;
                }
            }

            if (!Input.GetKey(KeyCode.Space)) //whenever the player lets go of the space button, they will stop jumping.
            {
                isJumping = false;
            }
        }
	}


	private void Flip()
	{
		// Switch the direction of the player
		facingRight = !facingRight;

		// Simply just change the sign of the vector
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

    public void Dash()
    {
        if (Time.time > nextDashTime && canDash) // makes sure the dash cooldown has finished and the player has touched the ground since dashing previously
        {
            if (Input.GetAxisRaw("Horizontal") != 0) 
            {
                //if the player is pressing in a horizontal direction, they will dash in that direction
                Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
                rigidbody2D.velocity = new Vector2(12 * direction.x, 0);
            } else {
                //if the player is not pressing a direction, they will dash in the direction they're facing
                int direction;
                if (facingRight)
                {
                    direction = 1;
                }
                else
                {
                    direction = -1;
                }
                rigidbody2D.velocity = new Vector2(12 * direction, 0);
            }
            isDashing = true;
            isJumping = false;
            canDash = false; //makes it so that the player can't dash until they touch the ground
            nextDashTime = Time.time + dashCooldownTime; //sets the next time when the player can dash
        }
    }
}

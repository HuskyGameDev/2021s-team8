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
	private bool grounded;								 // true or false whether the player is on the ground
	private Rigidbody2D rigidbody2D;
	private bool facingRight = true;					// Determines which way the player is facing
	private Vector3 velocity = Vector3.zero;

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
				if (!wasGrounded && rigidbody2D.velocity.y < 0)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool jump)
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
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
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
}

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	// Constant
	const float jumpCheckPreventionTime = 0.5f;

	// Public
	[Header("Physic Setting")]
	public LayerMask groundLayerMask;

	[Header("Move & Jump Setting")]
	public float moveSpeed = 10;
	public float fallWeight = 5.0f;
	public float jumpWeight = 0.5f;
	public float jumpVelocity = 100.0f;

	// Internal Data

	// State of the player (jumping or not)
	protected bool jumping = false;			// state of player (jumping or not )

	//
	protected Vector3 moveVec = Vector3.zero; // movement speed of player
	protected float jumpTimestamp;			// start jump timestamp
	
	protected Rigidbody rigidbody;			// reference to the rigidbody


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody>();
	}
	
	// void UpdateWhenJumping()
	// {
	// 	bool isFalling = rigidbody.velocity.y <= 0;
	//
	// 	float weight = isFalling ? fallWeight : jumpWeight;
	//
	// 	// Assign new velocity
	// 	rigidbody.velocity = new Vector3(moveVec.x * moveSpeed, rigidbody.velocity.y, moveVec.z * moveSpeed);
	// 	rigidbody.velocity += Vector3.up * Physics.gravity.y * weight * Time.deltaTime;
	//
	// 	GroundCheck();
	// }

	void UpdateWhenGrounded()
	{
		// 1 
		rigidbody.velocity = moveVec * moveSpeed;

		// 2
		if (moveVec != Vector3.zero)
		{
			transform.LookAt(this.transform.position + moveVec.normalized);
		}

		// 3
		CheckShouldFall();
	}

	private void FixedUpdate()
	{
		if (jumping == false)
		{
			// 2
			UpdateWhenGrounded();
		}
		// else
		// {
		// 	// 3
		// 	UpdateWhenJumping();
		// }
	}


	

	public void OnMove(InputValue input)
    {
		Vector2 inputVec = input.Get<Vector2>();

		moveVec = new Vector3(inputVec.x, 0, inputVec.y);
    }

	#region Jump & Fall & Ground Logic
	

	void CheckShouldFall()
	{
		if(jumping)
		{
			return;	// No need to check if in the air
		}

		bool hasHit = Physics.CheckSphere(transform.position, 0.1f, groundLayerMask);

		if (hasHit == false)
		{
			jumping = true;
		}
	}

	void GroundCheck()
	{
		if(jumping == false)
		{
			return;	// No need to check
		}

		if (Time.time < jumpTimestamp + jumpCheckPreventionTime)
		{
			return;
		}

		bool hasHit = Physics.CheckSphere(transform.position, 0.1f, groundLayerMask);
		
		if(hasHit)
		{
			jumping = false;
		}
	}

	#endregion

	

	

}

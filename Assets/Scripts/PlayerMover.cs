using UnityEngine;

[RequireComponent( typeof( Collider2D ), typeof( Rigidbody2D ) )]
public class PlayerMover : MonoBehaviour
{
	public bool canDoubleJump;
	public float jumpingForce;
	public float walkingSpeed;
	
	private int groundMask;
	private bool hasDoubleJumped;

	private Collider2D coll;
	private Rigidbody2D rbody;

	void Awake()
	{
		groundMask = LayerMask.GetMask( "Platform" );

		coll = GetComponent<Collider2D>();
		rbody = GetComponent<Rigidbody2D>();
	}

	public void Jump()
	{
		bool isGrounded = CheckIfGrounded();

		if ( isGrounded || (canDoubleJump && !hasDoubleJumped) )
		{
			rbody.AddForce( Vector2.up * jumpingForce, ForceMode2D.Impulse );
			hasDoubleJumped = !isGrounded;
		}
	}

	public void Walk( float offset )
	{
		Vector2 velocity = rbody.velocity;
		velocity.x = offset * walkingSpeed;
		rbody.velocity = velocity;
	}

	private bool CheckIfGrounded()
	{
		RaycastHit2D ground = Physics2D.Raycast( transform.position, Vector3.down, Mathf.Infinity, groundMask );
		return coll.IsTouching( ground.collider );
	}
}

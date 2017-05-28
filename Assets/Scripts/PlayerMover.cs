using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
public class PlayerMover : MonoBehaviour
{
	public float jumpingForce;
	public float walkingSpeed;

	private Rigidbody2D rbody;

	void Awake()
	{
		rbody = GetComponent<Rigidbody2D>();
	}

	public void Jump()
	{
		rbody.AddForce( Vector2.up * jumpingForce, ForceMode2D.Impulse );
	}

	public void Walk( float offset )
	{
		Vector2 velocity = rbody.velocity;
		velocity.x = offset * walkingSpeed;
		rbody.velocity = velocity;
	}
}

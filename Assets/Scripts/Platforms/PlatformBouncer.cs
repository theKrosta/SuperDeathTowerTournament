using UnityEngine;

public class PlatformBouncer : MonoBehaviour
{
	public float bounceForce;

	void OnCollisionEnter2D( Collision2D collision )
	{
		if ( collision.gameObject.CompareTag( "Player" ) &&
		     collision.transform.position.y > transform.position.y )
		{
			collision.rigidbody.AddForce( Vector2.up * bounceForce, ForceMode2D.Impulse );
		}
	}
}

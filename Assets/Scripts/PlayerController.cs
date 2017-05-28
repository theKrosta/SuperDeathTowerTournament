using UnityEngine;

[RequireComponent( typeof( PlayerMover ) )]
public class PlayerController : MonoBehaviour
{
	private PlayerMover mover;

	void Awake()
	{
		mover = GetComponent<PlayerMover>();
	}

	void Update()
	{
		if ( Input.GetButtonDown( "Jump" ) )
		{
			mover.Jump();
		}

		float hor = Input.GetAxisRaw( "Horizontal" );
		mover.Walk( hor );
	}
}

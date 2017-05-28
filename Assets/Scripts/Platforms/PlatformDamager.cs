using System.Collections.Generic;
using UnityEngine;

public class PlatformDamager : MonoBehaviour
{
	private enum State : byte
	{
		Deactivated,
		Activating,
		Activated
	};

	public float activationDelay;
	public float deactivationDelay;
	public Sprite defaultSprite;
	public Sprite damagingSprite;
	
	private float lastStateChange;
	private State state;
	private List<GameObject> collidingPlayers;

	private SpriteRenderer rend;

	void Awake()
	{
		state = State.Deactivated;
		collidingPlayers = new List<GameObject>();

		rend = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		if ( state == State.Activating && lastStateChange + activationDelay < Time.time )
		{
			ChangeState( State.Activated );
		}
		else if ( state == State.Activated && lastStateChange + deactivationDelay < Time.time )
		{
			ChangeState( State.Deactivated );
		}

		if ( state == State.Activated )
		{
			foreach ( GameObject player in collidingPlayers )
			{
				Debug.Log( player.ToString() + " è stato danneggiato!" ); // TODO: Far perdere il controllo.
			}
		}
	}

	void OnCollisionEnter2D( Collision2D collision )
	{
		if ( collision.gameObject.CompareTag( "Player" ) &&
			 collision.transform.position.y > transform.position.y )
		{
			collidingPlayers.Add( collision.gameObject );

			if ( state == State.Deactivated )
			{
				ChangeState( State.Activating );
			}
		}
	}

	void OnCollisionExit2D( Collision2D collision )
	{
		collidingPlayers.Remove( collision.gameObject );
	}

	private void ChangeState( State newState )
	{
		state = newState;
		rend.sprite = state == State.Activated ? damagingSprite : defaultSprite;
		lastStateChange = Time.time;
	}
}

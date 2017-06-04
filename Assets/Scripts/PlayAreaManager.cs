using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
public class PlayAreaManager : MonoBehaviour
{
	private const float screenHeight = 16.875f;

	public float minSpeed;
	public float maxSpeed;

	private Rigidbody2D rbody;

	void Awake()
	{
		rbody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		float averageY = 0;

		if ( GameManager.instance.players.Count > 0 )
		{
			foreach ( PlayerController player in GameManager.instance.players )
			{
				averageY += player.transform.position.y;
			}

			averageY /= GameManager.instance.players.Count;
		}

		float speedFactor = ((averageY - transform.position.y) / screenHeight ) + 0.5f;
		float speed = Mathf.Lerp( minSpeed, maxSpeed, speedFactor );
		rbody.velocity = Vector3.up * speed;
	}
}

using UnityEngine;

public class CameraManager : MonoBehaviour
{
	private const float screenHeight = 16.875f;

	public float minSpeed;
	public float maxSpeed;
	
	void LateUpdate()
	{
		float averageY = 0;

		if ( GameManager.instance.players.Count > 0 )
		{
			foreach ( GameObject player in GameManager.instance.players )
			{
				averageY += player.transform.position.y;
			}

			averageY /= GameManager.instance.players.Count;
		}

		float speedFactor = ((averageY - transform.position.y) / screenHeight) + 0.5f;
		float speed = Mathf.Max( Mathf.Lerp( minSpeed, maxSpeed, speedFactor ), minSpeed );
		Vector3 offset = Vector3.up * speed * Time.deltaTime;

		transform.Translate( offset );
	}
}

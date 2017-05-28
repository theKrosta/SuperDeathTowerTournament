using UnityEngine;

public class Killzone : MonoBehaviour
{
	void OnTriggerEnter2D( Collider2D collision )
	{
		Destroy( collision.gameObject );
	}
}

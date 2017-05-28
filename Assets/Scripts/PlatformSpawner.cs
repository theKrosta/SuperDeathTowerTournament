using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
	public float spawningGap;
	[Range( 0.0f, 1.0f )] public float specialPlatformChance;
	public GameObject standardPlatform;
	public GameObject[] specialPlatforms;
	public float[] spawnPoints;

	private float nextSpawnY;
	
	void Awake()
	{
		nextSpawnY = transform.position.y;
	}
	
	void Update()
	{
		if ( transform.position.y > nextSpawnY )
		{
			SpawnPlatforms( nextSpawnY );
			nextSpawnY += spawningGap;
		}
	}

	private void SpawnPlatforms( float y )
	{
		bool[] pattern = GeneratePattern();
		int specialPosition = -1;

		if ( Random.value < specialPlatformChance )
		{
			do
			{
				specialPosition = Random.Range( 0, spawnPoints.Length - 1 );
			}
			while ( !pattern[specialPosition] );
		}

		for ( int col = 0; col < spawnPoints.Length; col++ )
		{
			if ( pattern[col] )
			{
				GameObject toSpawn = standardPlatform;

				if ( col == specialPosition )
				{
					int rand = Random.Range( 0, specialPlatforms.Length - 1 );
					toSpawn = specialPlatforms[rand];
				}

				Vector2 spawnLocation = new Vector2( spawnPoints[col], y );
				Instantiate( toSpawn, spawnLocation, Quaternion.identity );
			}
		}
	}

	private bool[] GeneratePattern()
	{
		bool[] pattern = new bool[spawnPoints.Length];
		bool rand = Random.value < 0.5f;

		for ( int i = 0; i < spawnPoints.Length; i++ )
			pattern[i] = rand;

		int[] toInvert = { -1, -1 };

		while ( toInvert[0] == toInvert[1] )
		{
			toInvert[0] = Random.Range( 0, spawnPoints.Length );
			toInvert[1] = Random.Range( 0, spawnPoints.Length );
		}

		foreach ( int i in toInvert )
			pattern[i] = !pattern[i];

		return pattern;
	}
}

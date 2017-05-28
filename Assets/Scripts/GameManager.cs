using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	public List<GameObject> players;

	void Awake()
	{
		if ( instance == null )
		{
			instance = this;
			DontDestroyOnLoad( gameObject );
		}
		else if ( instance != this )
		{
			Destroy( gameObject );
		}
	}

	void Start()
	{
		players = new List<GameObject>();
	}
}

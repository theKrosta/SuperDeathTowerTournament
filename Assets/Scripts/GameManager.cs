using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance { get; private set; }

	[HideInInspector] public GameOverScreen gameOverScreen;

	public List<PlayerController> players { get; private set; }

	void Awake()
	{
		if ( instance == null )
		{
			instance = this;
			DontDestroyOnLoad( gameObject );

			players = new List<PlayerController>();
		}
		else if ( instance != this )
		{
			Destroy( gameObject );
		}
	}

	public void LoadScene( int index )
	{
		SceneManager.LoadScene( index );
	}

	public void AddPlayer( PlayerController player )
	{
		players.Add( player );
	}

	public void RemovePlayer( PlayerController player )
	{
		players.Remove( player );

		if ( players.Count == 1 )
		{
			GameOver();
		}
	}

	private void GameOver()
	{
		Time.timeScale = 0.5f;
		gameOverScreen.Display( players[0] );
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}

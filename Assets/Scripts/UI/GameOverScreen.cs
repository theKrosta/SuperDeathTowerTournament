using UnityEngine;

[RequireComponent( typeof( CanvasGroup ) )]
public class GameOverScreen : MonoBehaviour
{
	private CanvasGroup cgroup;

	void Awake()
	{
		cgroup = GetComponent<CanvasGroup>();
	}

	void Start()
	{
		GameManager.instance.gameOverScreen = this;
	}

	public void Display( PlayerController winner )
	{
		cgroup.alpha = 1.0f;
	}
}


using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : View
{
	[SerializeField] private Button _again;
	[SerializeField] private Button _quit;

	public static event Action RestartHud; 

	public void Start()
	{
		_again.onClick.AddListener(StartNewGame);
		_quit.onClick.AddListener(OpenMainMenu);
	}

	private void OpenMainMenu()
	{
		AudioManager.Play("ClickButton");

		AudioManager.Stop("ThemeGame");
		AudioManager.Play("ThemeMenu");

		ViewManager.Instance.TriggerClose(this);

		SceneManager.LoadScene(0);

		Time.timeScale = 1f;
	}

	private void StartNewGame()
	{
		AudioManager.Play("ClickButton");

		ViewManager.Instance.TriggerClose(this);

		GameSceneManager.TriggerClose(Game.Instance);

		var gameScene = GameSceneManager.Instance.Game;
		GameSceneManager.Instance.TriggerOpen(gameScene);

		RestartHud?.Invoke();

		Time.timeScale = 1f;
	}
}
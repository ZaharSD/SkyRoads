
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : View
{
	[SerializeField] private Button _continueGame;
	[SerializeField] private Button _settingMenu;
	[SerializeField] private Button _backInMainMenu;

	public static event Action CheckGameState;

	private void Start()
	{
		_backInMainMenu.onClick.AddListener(OpenMainMenu);
		_settingMenu.onClick.AddListener(OpenSettingsMenu);
		_continueGame.onClick.AddListener(ContinueGame);
	}

	private void ContinueGame()
	{
		GameStateManager.SetState(GameState.Gameplay);

		AudioManager.Play("ClickButton");

		CheckGameState?.Invoke();

		AudioManager.Play("ThemeGame");
		AudioManager.Stop("ThemeMenu");

		ViewManager.Instance.TriggerClose(this);
	}

	private void OpenMainMenu()
	{
		AudioManager.Play("ClickButton");

		AudioManager.Stop("ThemeGame");
		AudioManager.Play("ThemeMenu");

		ViewManager.Instance.TriggerClose(this);

		SceneManager.LoadScene(0);
	}

	private void OpenSettingsMenu()
	{
		AudioManager.Play("ClickButton");

		ViewManager.Instance.TriggerClose(this);

		var settingsAudioMenu = ViewManager.Instance.SettingsAudioMenu;
		ViewManager.Instance.TriggerOpen(settingsAudioMenu);
	}
}
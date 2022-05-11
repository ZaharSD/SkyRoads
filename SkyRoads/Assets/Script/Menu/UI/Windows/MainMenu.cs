
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : View
{
	[SerializeField] private Button _newGame;
	[SerializeField] private Button _records;
	[SerializeField] private Button _settings;
	[SerializeField] private Button _quit;

	public void Start()
	{
		SaveManager.LoadDate();

		_newGame.onClick.AddListener(StartGame);
		_settings.onClick.AddListener(OpenSettingsAudioMenu);
		_quit.onClick.AddListener(OpenViewExitConfirmation);
		_records.onClick.AddListener(OpenRecordsMenu);
	}

	private void OpenViewExitConfirmation()
	{
		AudioManager.Play("ClickButton");

		ViewManager.Instance.TriggerClose(this);

		var exitConfirmation = ViewManager.Instance.ExitConfirmation;
		ViewManager.Instance.TriggerOpen(exitConfirmation);
	}

	private void StartGame()
	{
		AudioManager.Play("ClickButton");

		AudioManager.Stop("ThemeMenu");
		AudioManager.Play("ThemeGame");

		GameStateManager.SetState(GameState.Gameplay);
		Time.timeScale = 1f;

		var gameScene = GameSceneManager.Instance.Game;
		GameSceneManager.Instance.TriggerOpen(gameScene);

		ViewManager.Instance.TriggerClose(this);

		if (SettingsAudioMenu.Instance != null)
			SettingsAudioMenu.Destroy();

		GameSceneManager.TriggerClose(Menu.Instance);
	}

	private void OpenRecordsMenu()
	{
		AudioManager.Play("ClickButton");

		ViewManager.Instance.TriggerClose(this);

		var recordMenu = ViewManager.Instance.RecordMenu;
		ViewManager.Instance.TriggerOpen(recordMenu);

		ControlListRecords.Load();
	}

	private void OpenSettingsAudioMenu()
	{
		AudioManager.Play("ClickButton");

		ViewManager.Instance.TriggerClose(this);

		var settingsMenu = ViewManager.Instance.SettingsAudioMenu;
		ViewManager.Instance.TriggerOpen(settingsMenu);
	}
}
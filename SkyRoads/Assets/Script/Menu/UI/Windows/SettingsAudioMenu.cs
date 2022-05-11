
using UnityEngine;
using UnityEngine.UI;

public class SettingsAudioMenu : View
{
	[SerializeField] private Button _backInMainMenu;

	public static SettingsAudioMenu Instance;

	private void Start()
	{
		_backInMainMenu.onClick.AddListener(OpenMainMenu);
	}

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);
	}

	public static void Destroy()
	{
		Destroy(Instance.gameObject);
	}

	private void OpenMainMenu()
	{
		AudioManager.Play("ClickButton");

		if (Menu.Instance != null)
		{
			ViewManager.Instance.TriggerClose(this);

			var mainMenu = ViewManager.Instance.MainMenu;
			ViewManager.Instance.TriggerOpen(mainMenu);
		}
		else
		{
			ViewManager.Instance.TriggerClose(this);

			var pauseMenu = ViewManager.Instance.PauseMenu;
			ViewManager.Instance.TriggerOpen(pauseMenu);
		}
	}
}
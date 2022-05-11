
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecordMenu : View
{
	[SerializeField] private Button _backInMainMenu;

	public void Start()
	{
		_backInMainMenu.onClick.AddListener(OpenMainMenu);
	}

	private void OpenMainMenu()
	{
		AudioManager.Play("ClickButton");

		var indexScene = SceneManager.GetActiveScene().buildIndex;

		if (indexScene == 0)
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
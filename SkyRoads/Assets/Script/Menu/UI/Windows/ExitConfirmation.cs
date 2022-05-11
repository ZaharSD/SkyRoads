
using UnityEngine;
using UnityEngine.UI;

public class ExitConfirmation : View
{
	[SerializeField] private Button _exitYes;
	[SerializeField] private Button _exitNo;

	public void Start()
	{
		_exitYes.onClick.AddListener(ExitApplication);
		_exitNo.onClick.AddListener(OpenMainMenu);
	}

	private void ExitApplication()
	{
		AudioManager.Play("ClickButton");

		Application.Quit();
	}

	private void OpenMainMenu()
	{
		AudioManager.Play("ClickButton");

		ViewManager.Instance.TriggerClose(this);

		var mainMenu = ViewManager.Instance.MainMenu;
		ViewManager.Instance.TriggerOpen(mainMenu);
	}
}

using UnityEngine;

public class ViewManager : MonoBehaviour
{
	public MainMenu MainMenu;
	public ExitConfirmation ExitConfirmation;
	public SheetChange SheetChange;
	public HUD HUD;
	public SettingsAudioMenu SettingsAudioMenu;
	public PauseMenu PauseMenu;
	public EndGame LoseMenu;
	public EndGame WinGame;
	public RecordMenu RecordMenu;

	public static ViewManager Instance;

	private static bool _isFirstStart = true;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else
			Destroy(gameObject);

		if (_isFirstStart && PlayerPrefs.GetInt("Comics") != 1)
		{
			TriggerOpen(SheetChange);
			_isFirstStart = false;
		}
		else
			TriggerOpen(MainMenu);
	}

	public void TriggerClose(View view)
	{
		view.Hide();
	}

	public void TriggerOpen(View view)
	{
		var inactiveWindow = FindOpenedWindow(view);

		if (inactiveWindow != null)
			inactiveWindow.Show();
		else
			Instantiate(view, gameObject.transform);
	}

	private View FindOpenedWindow(View window)
	{
		var openedWindows = gameObject.transform.GetComponentsInChildren<View>(true);

		foreach (var openedWindow in openedWindows)
		{
			if (openedWindow.GetType() == window.GetType())
				return openedWindow;
		}

		return null;
	}
}
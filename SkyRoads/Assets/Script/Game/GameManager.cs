
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private ConfigData _currentConfigData;

	public int PassedTiles;

	public static GameManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;

		var hud = ViewManager.Instance.HUD;
		ViewManager.Instance.TriggerOpen(hud);
	}

	private void Start()
	{
		Road.AddPassedTitles += AddScorePassedTitles;

		ConfigDataManager.ResetDifficulty();

		_currentConfigData = ConfigDataManager.ConfigData.Pop();
	}

	private void Update()
	{
		ToggleDifficultyMode();
	}

	private void ToggleDifficultyMode()
	{
		if (PassedTiles >= _currentConfigData.MaxCount)
		{
			if (ConfigDataManager.ConfigData.Count > 0)
			{
				_currentConfigData = ConfigDataManager.ConfigData.Pop();

				AsteroidManager.OccurrenceFrequencyAsteroid = _currentConfigData.Frequency;
			}
		}
	}

	private void AddScorePassedTitles()
	{
		PassedTiles++;
	}
}
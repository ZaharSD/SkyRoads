
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HUD : View
{
	[Header("PauseButton")]
	[SerializeField] private Button _pauseGame;

	[Header("Timer")] 
	[SerializeField] private Text _textTimer;

	[Header("Score")] 
	[SerializeField] private Text _textScore;

	[Header("Record")] 
	[SerializeField] private Text _textRecord;

	public static int CountScore { get; private set; }

	public static int Second { get; private set; }

	public static int Minute { get; private set; }

	private void StopTime()
	{
		Time.timeScale = 0f;
	}

	private void StartTime()
	{
		Time.timeScale = 1f;
	}

	private void Awake()
	{
		PauseMenu.CheckGameState += StartTime;
		EndGame.RestartHud += RestartHud;
	}

	private void Start()
	{
		CountScore = 0;
		Second = 0;
		Minute = 0;

		_pauseGame.onClick.AddListener(OpenPauseMenu);

		StartCoroutine(AddScore());

		StartCoroutine(TimeCounter());

		_textRecord.text = Convert.ToString(RecordManager.GetRecord());
	}

	private void OpenPauseMenu()
	{
		AudioManager.Play("ClickButton");

		AudioManager.Stop("ThemeGame");
		AudioManager.Play("ThemeMenu");

		GameStateManager.SetState(GameState.Paused);

		StopTime();

		var pauseMenu = ViewManager.Instance.PauseMenu;
		ViewManager.Instance.TriggerOpen(pauseMenu);
	}

	private IEnumerator TimeCounter()
	{
		while (true)
		{
			if (Second == 59)
			{
				Minute++;
				Second = -1;
			}

			Second++;

			_textTimer.text = Minute.ToString("00") + " : " + Second.ToString("00");
			yield return new WaitForSeconds(1);
		}
	}

	private IEnumerator AddScore()
	{
		while (true)
		{
			CountScore++;
			if (Road.GetAcceleration() >= 0.6f)
				CountScore++;

			_textScore.text = CountScore.ToString();

			yield return new WaitForSeconds(1);
		}
	}

	private void RestartHud()
	{
		Second = 0;
		Minute = 0;

		CountScore = 0;
	}

	private void OnDestroy()
	{
		PauseMenu.CheckGameState -= StartTime;
	}
}
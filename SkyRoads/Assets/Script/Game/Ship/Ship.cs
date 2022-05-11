
using UnityEngine;
using System;

public class Ship : MonoBehaviour
{
	[SerializeField] private float _sensitivityMove = 100;

	private void Update()
	{
		if (GameStateManager.CurrentGameState == GameState.Gameplay) 
			MoveShip();
	}

	private void MoveShip()
	{
#if UNITY_ANDROID || UNITY_IOS
		var accelerationAndroid = Input.acceleration;

		transform.rotation = Quaternion.Euler(0f, 0f, -accelerationAndroid.x * 80f);

		if (transform.position.x + accelerationAndroid.x * Time.deltaTime * _sensitivityMove <= 23f &&
			transform.position.x + accelerationAndroid.x * Time.deltaTime * _sensitivityMove >= -23f)
			transform.position += new Vector3(accelerationAndroid.x * Time.deltaTime * _sensitivityMove, 0f, 0f);
#endif
#if UNITY_EDITOR
		transform.rotation = Quaternion.Euler(0f, 0f, -Input.GetAxis("Horizontal") * 50f);

		if (transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * _sensitivityMove <= 23f &&
			transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * _sensitivityMove >= -23f)
			transform.position += new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * _sensitivityMove, 0f, 0f);
#endif
	}

	private void OnTriggerEnter(Collider other)
	{
		AudioManager.Play("DestroyShip");

		Time.timeScale = 0f;

		if (HUD.CountScore > RecordManager.GetRecord())
		{
			RecordManager.SaveRecord(HUD.CountScore);

			var winMenu = ViewManager.Instance.WinGame;
			ViewManager.Instance.TriggerOpen(winMenu);
		}
		else
		{
			var loseMenu = ViewManager.Instance.LoseMenu;
			ViewManager.Instance.TriggerOpen(loseMenu);
		}

		var record = new Record(DateTime.Now, HUD.CountScore, HUD.Second, HUD.Minute);

		ControlListRecords.Add(record);
	}
}
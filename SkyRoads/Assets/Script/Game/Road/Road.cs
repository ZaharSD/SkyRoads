
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Road : MonoBehaviour
{
	[SerializeField] private float _speedMoveRoad = 130f;
	[SerializeField] private Camera _camera;
	
	public static event Action<Transform> SpawnAsteroid;
	public static event Action AddPassedTitles;

	private Queue<Transform> _partsRoad;

	private readonly float _speedAcceleration = 50f;
	private int _count;

	private void Start()
	{
		_partsRoad = new Queue<Transform>(transform.GetComponentsInChildren<Transform>()
			.Where(_partsRoad => _partsRoad != transform));

		StartCoroutine(AccelerationRoad());

		StartCoroutine(TurboMode());
	}

	private void Update()
	{
		if (GameStateManager.CurrentGameState == GameState.Gameplay)
			MoveRoad();
	}

	private void MoveRoad()
	{
		var acceleration = Input.acceleration;

		transform.localPosition -= Vector3.forward * Mathf.Abs(acceleration.z) * (Time.deltaTime * 10);

		var transformPosition = transform.position;
		transformPosition.z -= _speedMoveRoad * Time.deltaTime;

		transform.position = transformPosition;

		if (_partsRoad.Peek().transform.position.z <= _camera.transform.position.z - 3f)
		{
			AddPassedTitles?.Invoke();

			var lastPart = _partsRoad.Dequeue();
			lastPart.position = new Vector3(0f, 0f, _partsRoad.Last().position.z + 70f);
			_partsRoad.Enqueue(lastPart);

			SpawnAsteroid?.Invoke(lastPart);
			AddPassedTitles?.Invoke();
		}
	}

	private IEnumerator TurboMode()
	{
		while (true)
		{
			if (Input.GetAxis("Vertical") >= 0.8f)
			{
				_speedMoveRoad += _speedAcceleration;

				_count++;
			}
			else if (Input.GetAxis("Vertical") < 0.8f)
			{
				while (_count > 0)
				{
					if (Input.GetAxis("Vertical") > 0.8f)
						break;
					_count--;
					_speedMoveRoad -= _speedAcceleration;
					yield return new WaitForSeconds(0.2f);
				}
			}

			yield return new WaitForSeconds(0.2f);
		}

#if UNITY_ANDROID || UNITY_IOS
		while (true)
		{
			var acceleration = Input.acceleration;

			if (Mathf.Abs(acceleration.z) >= 0.7f)
			{
				_speedMoveRoad += _speedAcceleration;

				_count++;
			}
			else if (Mathf.Abs(acceleration.z) < 0.7f)
			{
				while (_count > 0)
				{
					if (Mathf.Abs(acceleration.z) > 0.7f)
						break;
					_count--;
					_speedMoveRoad -= _speedAcceleration;
					yield return new WaitForSeconds(0.2f);
				}
			}

			yield return new WaitForSeconds(0.2f);
		}
#endif
	}

	private IEnumerator AccelerationRoad()
	{
		while (true)
		{
			_speedMoveRoad += 5;

			yield return new WaitForSeconds(1);
		}
	}

	public static float GetAcceleration()
	{
		return Input.GetAxis("Vertical");
#if UNITY_ANDROID || UNITY_IOS
		var accelerationAndroid = Input.acceleration;

		return Mathf.Abs(accelerationAndroid.z);
#endif
	}
}
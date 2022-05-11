
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
	[SerializeField] private int _poolCount = 40;
	[SerializeField] private Asteroid _prefabAsteroid;
	[SerializeField] private Transform _container;
	
	private static Pool<Asteroid> _pool;

	private readonly List<Vector3> _pointSpawn = new List<Vector3>
		{new Vector3(-3.2f, 1.25f, 0f), new Vector3(0f, 1.25f, 0f), new Vector3(3.2f, 1.25f, 0f)};

	public static float OccurrenceFrequencyAsteroid { get; set; }

	private void Awake()
	{
		Asteroid.Deactivate += OnDeactivate;
		Road.SpawnAsteroid += OnSpawnAsteroid;
		_pool = new Pool<Asteroid>(_prefabAsteroid, _poolCount, _container);
	}

	private void OnSpawnAsteroid(Transform lastPart)
	{
		if (Random.Range(0, 100) <= OccurrenceFrequencyAsteroid)
		{
			if (Random.Range(0, 100) <= 15)
			{
				var point01 = Random.Range(0, _pointSpawn.Count);

				var values = Enumerable.Range(0, _pointSpawn.Count).Where(item => item != point01).ToArray();

				var point02 = Random.Range(0, values.Length);
				
				var asteroid1 = _pool.GetFreeElement();
				asteroid1.transform.SetParent(lastPart, false);
				asteroid1.transform.localPosition = new Vector3(_pointSpawn[point01].x, _pointSpawn[point01].y, 0);

				var asteroid2 = _pool.GetFreeElement();
				asteroid2.transform.SetParent(lastPart, false);
				asteroid2.transform.localPosition = new Vector3(_pointSpawn[point01].x, _pointSpawn[point02].y, 0);
			}
			else
			{
				var point01 = Random.Range(0, _pointSpawn.Count);

				var asteroid1 = _pool.GetFreeElement();
				asteroid1.transform.SetParent(lastPart, false);
				asteroid1.transform.localPosition = new Vector3(_pointSpawn[point01].x, _pointSpawn[point01].y, 0);
				
			}
		}
	}

	private void OnDeactivate(Asteroid asteroid)
	{
		_pool.DeactivateElement(asteroid);
	}
}
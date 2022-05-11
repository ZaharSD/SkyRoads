﻿
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
	private T _prefab { get; }
	private readonly Transform _container;

	private List<T> _pool;

	public Pool(T prefab, int count, Transform container)
	{
		_prefab = prefab;
		_container = container;

		CreatePool(count);
	}

	private void CreatePool(int count)
	{
		_pool = new List<T>();

		for (var i = 0; i < count; i++) 
			CreateObject();
	}

	private T CreateObject(bool isActiveByDefault = false)
	{
		var createObject = Object.Instantiate(_prefab, _container);

		createObject.gameObject.SetActive(false);

		_pool.Add(createObject);

		return createObject;
	}

	public bool HasFreeElement(out T element)
	{
		foreach (var item in _pool)
		{
			if (!item.gameObject.activeInHierarchy)
			{
				element = item;
				item.gameObject.SetActive(true);

				return true;
			}
		}

		element = null;
		return false;
	}

	public T GetFreeElement()
	{
		if (HasFreeElement(out var element))
			return element;
		return CreateObject(true);
	}

	public void DeactivateElement(T element)
	{
		element.gameObject.SetActive(false);
	}
}
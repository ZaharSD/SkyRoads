
using System;
using UnityEngine;

public abstract class View : MonoBehaviour
{
	[SerializeField] private bool _isOpen = true;

	public virtual void Hide()
	{
		if (_isOpen)
		{
			_isOpen = false;
			gameObject.SetActive(_isOpen);
		}
	}

	public virtual void Show()
	{
		if (!_isOpen)
		{
			_isOpen = true;
			gameObject.SetActive(_isOpen);
		}
	}

	public virtual void Initialize(object data)
	{
	}
}
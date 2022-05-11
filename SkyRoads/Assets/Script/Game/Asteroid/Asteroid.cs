
using System;
using DG.Tweening;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public static event Action<Asteroid> Deactivate;
	
	private Tween _rotateMoveTween;

	private void Update()
	{
		if (gameObject == null)
			_rotateMoveTween.Kill();
	}

	private void Start()
	{
		var rotation = new Vector3(0, 360, 0);

		_rotateMoveTween = transform.DOLocalRotate(rotation, 2).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear)
			.SetRelative();
	}

	private void OnTriggerExit(Collider other)
	{
		Deactivate?.Invoke(this);
	}
}
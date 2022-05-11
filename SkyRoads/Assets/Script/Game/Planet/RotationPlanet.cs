
using DG.Tweening;
using UnityEngine;

public class RotationPlanet : MonoBehaviour
{
	private void Start()
	{
		var rotation = new Vector3(0, 360, 0);

		transform.DOLocalRotate(rotation, 20).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetRelative();
	}
}
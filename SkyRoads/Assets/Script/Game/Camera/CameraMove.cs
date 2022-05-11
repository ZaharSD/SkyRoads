
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	[SerializeField] private Transform _ship;

	private void FixedUpdate()
	{
		MoveToObject();
	}

	private void MoveToObject()
	{
#if UNITY_ANDROID
		var accelerationAndroid = Input.acceleration;

		transform.position = new Vector3(Mathf.Lerp(transform.position.x, _ship.position.x, Time.deltaTime * 2f),
			transform.position.y, Mathf.Lerp(16f, -30f, Mathf.Abs(accelerationAndroid.z) * Time.deltaTime * 300f));
#endif
#if UNITY_IOS
		var accelerationIOS = Input.acceleration;

		transform.position = new Vector3(Mathf.Lerp(transform.position.x, _ship.position.x, Time.deltaTime * 2f),
			transform.position.y, Mathf.Lerp(16f, -30f, Mathf.Abs(accelerationIOS.z) * Time.deltaTime * 300f));
#endif
#if UNITY_EDITOR
		var accelerationEditor = Input.GetAxis("Vertical");

		transform.position = new Vector3(Mathf.Lerp(transform.position.x, _ship.position.x, Time.deltaTime * 2f),
			transform.position.y, Mathf.Lerp(16f, -16f, accelerationEditor * Time.deltaTime * 100f));
#endif
	}
}

using UnityEngine;
using UnityEngine.UI;

public class SlidersManager : MonoBehaviour
{
	[SerializeField] private Slider _sliderTheme;
	[SerializeField] private Slider _sliderEffects;

	private void Awake()
	{
		_sliderTheme.onValueChanged.AddListener(AudioManager.ChangeVolumeTheme);
		_sliderEffects.onValueChanged.AddListener(AudioManager.ChangeVolumeEffects);
	}
}
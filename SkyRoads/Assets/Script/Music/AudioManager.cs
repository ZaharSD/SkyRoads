
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private List<Sound> _sounds;

	[SerializeField] private AudioMixerGroup _mixer;

	private static AudioManager _instance;

	private void Awake()
	{
		if (_instance == null)
			_instance = this;
		else
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);

		foreach (var s in _sounds)
		{
			s.Source = gameObject.AddComponent<AudioSource>();

			s.Source.clip = s.Clip;
			s.Source.outputAudioMixerGroup = s.Mixer;

			s.Source.volume = s.Volume;
			s.Source.loop = s.Loop;
		}
	}

	private void Start()
	{
		Play("ThemeMenu");
	}

	public static void Play(string name)
	{
		var sound = _instance._sounds.Find(sound => sound.Name == name);

		if (sound == null)
			return;

		sound.Source.Play();
	}

	public static void Stop(string name)
	{
		var sound = _instance._sounds.Find(sound => sound.Name == name);

		if (sound == null)
			return;

		sound.Source.Stop();
	}

	public static void ChangeVolumeTheme(float valumeBackground)
	{
		_instance._mixer.audioMixer.SetFloat("Background", Mathf.Lerp(-50, 0, valumeBackground));
	}

	public static void ChangeVolumeEffects(float valumeEffects)
	{
		_instance._mixer.audioMixer.SetFloat("Effects", Mathf.Lerp(-50, 0, valumeEffects));
	}
}
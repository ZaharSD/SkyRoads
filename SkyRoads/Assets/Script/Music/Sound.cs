
using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
	public string Name;

	public AudioClip Clip;

	public AudioMixerGroup Mixer;

	[Range(0f, 1f)] public float Volume;

	public bool Loop;

	[HideInInspector] public AudioSource Source;
}
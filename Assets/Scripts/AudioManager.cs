using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

	public static AudioManager SP;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		if (SP != null)
		{
			Destroy(gameObject);
		}
		else
		{
			SP = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    void Start()
    {
        Sound s = Array.Find(sounds, item => item.name == "MusicIntro");
        double clipLength = (double)s.source.clip.samples / s.source.clip.frequency;

        StartCoroutine(ContinueMusic(clipLength));
    }

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

    public IEnumerator ContinueMusic(double introLength)
    {
        Play("MusicIntro");
        yield return new WaitForSecondsRealtime((float)introLength);
        Play("MusicLoop");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager inst;
    public Audio[] audios;
    
    void Awake()
    {
        if (inst == null) inst = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Audio aud in audios) {
            aud.source = gameObject.AddComponent<AudioSource>();
            aud.source.outputAudioMixerGroup = aud.audioMixerGroup;
            aud.source.clip = aud.clip;
            aud.source.volume = aud.volume;
            aud.source.pitch = aud.pitch;
            aud.source.loop = aud.loop;
        }
    }

    public void Play(string name) {
        Audio aud = Array.Find(audios, audio => audio.name == name);
        if (aud == null) return;
        aud.source.Play();
    }

    public void Stop(string name) {
        Audio aud = Array.Find(audios, audio => audio.name == name);
        if (aud == null) return;
        aud.source.Stop();
    }
}

[Serializable]
public class  Audio {
    public string name;
    
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(-3f, 3f)]
    public float pitch;
    public AudioMixerGroup audioMixerGroup;

    public bool loop;
    [HideInInspector]
    public AudioSource source;
}

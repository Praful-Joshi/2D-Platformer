using UnityEngine;
using System;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{

    public static SFXManager sfxInstance; //Singleton instance of this class

    public Sound[] sounds;

    private void Awake()
    {
        //Creating Singleton
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            sfxInstance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.PlayOnAwake;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

        Play("Background");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.Log("Typo");
            return;
        }
        s.source.Play();
    }
}

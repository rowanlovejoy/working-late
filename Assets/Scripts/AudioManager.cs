using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/*
 * The code in this script is based on a publically available YouTube tutorial produced by user Brackeys (2017)
 * For the full reference to this source, along with others used for this Design Challenge 01, see Documentation\Design Challenge 01\3rd Party Assets\Design Challenge 01 Reference List.pdf
 * */

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    private class Sound
    {
        public string name;

        public AudioClip clip;

        [Range(0.0f, 1.0f)]
        public float volume = 1.0f;
        [Range(-3.0f, 3.0f)]
        public float pitch = 1.0f;

        public bool loop = false;
        public bool playOnAwake = false;

        [HideInInspector]
        public AudioSource source;
    }

    public static AudioManager instance;

    private List<string> m_currentlyPlayingSounds = new List<string>();

    [SerializeField]
    private Sound[] sounds;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        AddSounds();
    }

    private void AddSounds()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source = gameObject.AddComponent<AudioSource>();
            sounds[i].source.clip = sounds[i].clip;
            sounds[i].source.volume = sounds[i].volume;
            sounds[i].source.pitch = sounds[i].pitch;
            sounds[i].source.loop = sounds[i].loop;
            sounds[i].source.playOnAwake = sounds[i].playOnAwake;
        }
    }

    public void Play(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                if (sounds[i] != null && !sounds[i].source.isPlaying)
                {
                    sounds[i].source.Play();
                    m_currentlyPlayingSounds.Add(_name);
                }
                else if (sounds[i].source.isPlaying)
                {
                    Debug.Log("Sound: " + _name + " is already playing");
                }
                else
                {
                    Debug.Log("Sound: " + _name + " was not found.");
                }
            }
        }
    }

    public void Stop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                if (sounds[i].source.isPlaying)
                {
                    sounds[i].source.Stop();
                    if (m_currentlyPlayingSounds.Contains(_name))
                    {
                        m_currentlyPlayingSounds.Remove(_name);
                    }
                }
                else
                {
                    Debug.Log("Sound: " + _name + " is not playing");
                }
            }
        }
    }

    public void Pause(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                if (sounds[i].source.isPlaying)
                {
                    sounds[i].source.Pause();
                }
            }
        }
    }

    public void StopAll()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].source.isPlaying)
            {
                sounds[i].source.Stop();
            }
        }

        Debug.Log("All audio stopped");
    }

    public void FadeOutSound(string _sound, float _fadeOutDuration)
    {

    }

}
using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    //Note to self, try to change to a list of arrays for managing lists (IE: an array of BGM, an array of SFX, or other loose arrays
    public Sound[] sounds;
    public AudioMixer mixer;
    private string type;

    private void Awake()
    {

        //DontDestroyOnLoad(gameObject); Uncomment this line for multi-scene audio support
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            type = s.audioType.ToString();
            s.source.outputAudioMixerGroup = mixer.FindMatchingGroups(type)[0];
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " does not exist");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " does not exist");
            return;
        }
        s.source.Stop();
    }

}

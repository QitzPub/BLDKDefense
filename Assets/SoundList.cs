using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SoundList : MonoBehaviour
{
    List<AudioSource> sources;

    void Awake()
    {
        sources = GetComponents<AudioSource>().ToList();
    }

    public AudioSource GetAudioSource(int num, bool max)
    {
        if (0 <= num && num < sources.Count)
        {
            return sources[num];
        }
        else if(max)
        {
            return sources.Last();
        }
        return null;
    }

    public void SetVolume(float volume)
    {
        sources.ForEach(s => s.volume = volume);
    }
}

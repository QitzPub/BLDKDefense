using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BGM
{
    Title,
    LevelSelect,
    Level,
}

public enum SE
{
    Cansell,
    LevelClear,
    ZunkoAttack,
    KiritanAttack,
    Restart,
    LevelStart,
}

public class SoundManager : SingletonMonoBehaviour<SoundManager>
{
    [SerializeField] float bgmVolume;
    [SerializeField] float seVolume;

    [SerializeField] BGM bgmName;
    [SerializeField] List<AudioClip> bgms;
    [SerializeField] AudioSource bgmSource;

    [SerializeField] SE seName;
    [SerializeField] SoundList seList;

    void Start()
    {
        bgmSource.loop = true;
        bgmSource.volume = bgmVolume;
        //TODO SE volume
    }


    public void Play(BGM bgm)
    {
        bgmSource.clip = bgms[(int)bgm];
        bgmSource.Play();
    }

    void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void Play(SE se)
    {
        seList.GetAudioSource((int) se, true).Play();
    }

}

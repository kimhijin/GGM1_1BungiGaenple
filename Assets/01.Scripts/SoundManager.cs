using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("BGM")]
    public AudioClip bgmClip;
    public float bgmVolum;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmEffect;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolum;
    public int channels;
    AudioSource[] sfxPlayer;
    int channelIndex;

    public enum Sfx { GameOver, Win, GetCoin, Paper}

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
    }

    private void Init()
    {
        GameObject bgmObj = new GameObject("BgmPlayer");
        bgmObj.transform.parent = transform;
        bgmPlayer = bgmObj.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolum;
        bgmPlayer.clip = bgmClip;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        GameObject sfxObj = new GameObject("SfxPlayer");
        sfxObj.transform.parent = transform;
        sfxPlayer = new AudioSource[channels];

        for(int i = 0; i<sfxPlayer.Length; i++)
        {
            sfxPlayer[i] = sfxObj.AddComponent<AudioSource>();
            sfxPlayer[i].playOnAwake = false;
            sfxPlayer[i].bypassListenerEffects = true;
            sfxPlayer[i].volume = sfxVolum;
        }

        
    }

    public void PlayBgm(bool isPlay)
    {
        if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
            bgmPlayer.Play();
    }

    public void EffectBgm(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }

    public void PlaySfx(Sfx sfx)
    {
        for(int i = 0; i<sfxPlayer.Length; i++)
        {
            int loopIndex = (i + channelIndex) % sfxPlayer.Length;

            if (sfxPlayer[loopIndex].isPlaying)
                continue;

            channelIndex = loopIndex;
            sfxPlayer[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayer[loopIndex].Play();
            break;
        }
    }

    public void SoundCheCk(Slider slider)
    {
        for (int i = 0; i < sfxPlayer.Length; i++)
        {
            sfxPlayer[i].volume = slider.value;
        }
    }
    
    public void BgmCheck(Slider slider)
    {
        bgmPlayer.volume = slider.value;
    }
}

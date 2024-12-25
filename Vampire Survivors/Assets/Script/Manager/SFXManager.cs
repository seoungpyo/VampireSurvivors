using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : SingletonMonobehavior<SFXManager>
{
    public AudioSource[] soundEffect;

    protected override void Awake()
    {
        base.Awake();
    }

    public void PlaySFX(int sfxToPlay)
    {
        soundEffect[sfxToPlay].Stop();
        soundEffect[sfxToPlay].Play();
    }

    public void PlaySFXPitched(int sfxToPlay)
    {
        soundEffect[sfxToPlay].pitch = Random.Range(0.8f, 1.2f);

        PlaySFX(sfxToPlay);
    }
}

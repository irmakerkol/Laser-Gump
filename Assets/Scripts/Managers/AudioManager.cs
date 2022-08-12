using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource musicSource, effectSource;

    public void playSound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }
}
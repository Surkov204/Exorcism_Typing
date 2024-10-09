using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    private AudioSource soundScoure;


    private void Awake()
    {
        instance = this;
        soundScoure = GetComponent<AudioSource>();
 
    }
    public void PlaySound(AudioClip _Source)
    {
        soundScoure.PlayOneShot(_Source);
    }
}

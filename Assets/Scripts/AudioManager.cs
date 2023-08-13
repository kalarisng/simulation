using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip yourAudioClip1;
    public AudioClip yourAudioClip2;

    private AudioSource audioSource1;
    private AudioSource audioSource2;

    private void Start()
    {
        // Access or add AudioSources
        audioSource1 = GetComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        // Assign audio clips to AudioSources
        audioSource1.clip = yourAudioClip1;
        audioSource2.clip = yourAudioClip2;
    }
}

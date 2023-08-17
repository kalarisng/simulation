using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false; // Flag to track whether the audio is playing

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // Enable looping
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
        {
            PlayAudio();
        }
    }

    public void PlayAudio()
    {
        isPlaying = true;
        audioSource.Play();
    }

    public void StopAudio()
    {
        isPlaying = false;
        audioSource.enabled = false;
    }
}

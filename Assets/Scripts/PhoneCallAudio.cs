using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallAudio : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true; // Enable looping
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the audio clip is not playing
        if (!audioSource.isPlaying)
        {
            // Play the audio clip (it will loop automatically)
            audioSource.Play();
        }
    }

    public void StopAudio()
    {
        audioSource.Stop();
    }
}

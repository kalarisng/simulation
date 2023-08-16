using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneCallAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private int loopCount = 3;
    private int loopsRemaining;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        loopsRemaining = loopCount;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the audio clip is not playing and there are remaining loops
        if (!audioSource.isPlaying && loopsRemaining > 0)
        {
            // Play the audio clip
            audioSource.Play();
            loopsRemaining--;
        }
    }
}

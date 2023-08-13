using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DaughterButton : MonoBehaviour
{
    public Button[] buttons;  // Array to store references to the buttons
    public TextMeshProUGUI timestamp;
    public TextMeshProUGUI contact;
    public RawImage searchBar;
    public GameObject dialPage;

    public AudioClip firstAudioClip; // Assign in the Unity Inspector
    public AudioClip secondAudioClip; // Assign in the Unity Inspector
    public AudioClip thirdAudioClip; // Assign in the Unity Inspector

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false; // Don't play the audio on awake
        audioSource.loop = false; // Make sure looping is disabled
    }

    public void OnButtonClick()
    {
        Debug.Log("Daughter button clicked!");
        contact.gameObject.SetActive(false);
        searchBar.gameObject.SetActive(false);

        // Loop through the buttons and fade them away
        foreach (Button button in buttons)
        {
            // StartCoroutine(FadeButton(button));
            button.gameObject.SetActive(false);
        }

        // Play the first audio clip
        PlayAudioClip(firstAudioClip);

        // Set the dial page to be visible
        dialPage.SetActive(true);
    }

    private void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();

        // Schedule the next audio clip to play after the current clip finishes
        Invoke("PlayNextAudioClip", clip.length);
    }

    private void PlayNextAudioClip()
    {
        // Determine which audio clip to play next based on the current clip
        if (audioSource.clip == firstAudioClip)
        {
            PlayAudioClip(secondAudioClip);
        }
        else if (audioSource.clip == secondAudioClip)
        {
            PlayAudioClip(thirdAudioClip);
        }
    }
}

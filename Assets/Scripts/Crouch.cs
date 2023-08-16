using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController characterCollider;
    public Canvas healthBarCanvas;
    public GameObject crouchInstructionPanel;
    public GameObject crouchAudio;
    private AudioSource audioSource;

    private bool isCKeyPressed = false;
    private bool hasAudioPlayed = false; // Track whether the audio has played
    private float cKeyPressedStartTime = 0f;
    private float requiredHoldTime = 1.0f;

    void Start()
    {
        audioSource = crouchAudio.GetComponent<AudioSource>();
        characterCollider = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            if (!isCKeyPressed)
            {
                isCKeyPressed = true;
                cKeyPressedStartTime = Time.time;
            }
            crouchInstructionPanel.SetActive(false);
            if (!healthBarCanvas.gameObject.activeSelf)
            {
                healthBarCanvas.gameObject.SetActive(true);
            }
            characterCollider.height = 1.0f;
        }
        else
        {
            isCKeyPressed = false;
            characterCollider.height = 2.0f;
        }
        if (isCKeyPressed && !hasAudioPlayed && Time.time - cKeyPressedStartTime >= requiredHoldTime)
        {
            PlayAudioClip();
            hasAudioPlayed = true; // Set the flag to prevent multiple plays
        }
    }

    private void PlayAudioClip()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}

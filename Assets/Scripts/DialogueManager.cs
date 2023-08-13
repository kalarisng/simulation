using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public bool isDialogueActive = false;
    public bool startDisableClicker = true;
    public GameObject clicker;
    public StarterAssetsInputs starterAssetsInputs;
    public AudioSource audioSource1; // Add this variable for the first AudioSource
    public AudioSource audioSource2; // Add this variable for the second AudioSource
    public AudioClip yourAudioClip2;


    void Start()
    {
        sentences = new Queue<string>();
        audioSource1 = GetComponent<AudioSource>(); // Assuming the first AudioSource is already attached
        audioSource2 = gameObject.AddComponent<AudioSource>(); // Adding a new AudioSource component

        // Configure audioSource2 properties
        audioSource2.clip = yourAudioClip2; // Assign the AudioClip you want to play
        audioSource2.volume = 1.0f; // Adjust the volume as needed
        audioSource2.spatialBlend = 0.0f; // Adjust spatial blend for 2D audio
    }
    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }

    public bool IsClickerDisabled()
    {
        return startDisableClicker;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // AudioSource audioSource = GetComponent<AudioSource>();
        // audioSource.Play();
        audioSource1.Play();
        audioSource2.Play();

        animator.SetBool("isOpen", true);
        isDialogueActive = true;
        startDisableClicker = false;

        Debug.Log("Starting conversation...");
        sentences.Clear();
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        startDisableClicker = false;
        MouseLook.dialogueActive = false;
        animator.SetBool("isOpen", false);
        Debug.Log("End of dialogue");

        clicker.SetActive(true);

        // AudioSource audioSource = GetComponent<AudioSource>();
        // audioSource.Stop();
        audioSource1.Stop();
        audioSource2.Stop();

        starterAssetsInputs.DeactivateCanvas();
        Debug.Log("deactivated canvas");
    }
}

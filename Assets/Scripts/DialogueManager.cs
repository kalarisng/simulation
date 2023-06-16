using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public bool isDialogueActive = false;
    public bool startDisableClicker = true;
    
    public GameObject clicker;
    void Start()
    {
        sentences = new Queue<string>();
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
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
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

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
}

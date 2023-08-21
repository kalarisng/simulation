using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public CanvasGroup buttonCanvasGroup;
    public GameObject clicker;
    public float fadeDuration = 0.2f;
    public AudioSource audioSource;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        StartCoroutine(FadeButton());
    }

    private void Start()
    {
        // Disable at the start
        clicker.SetActive(false);
    }

    private void Update()
    {
        // Check if the dialogue is active
        if (FindObjectOfType<DialogueManager>().IsDialogueActive() || FindObjectOfType<DialogueManager>().IsClickerDisabled())
        {
            // Disable the clicker while the dialogue is active
            clicker.SetActive(false);
        }
        else
        {
            // Enable the clicker when the dialogue ends
            Debug.Log("Clicker enabled after dialogue ends");
            clicker.SetActive(true);
        }
    }

    private IEnumerator FadeButton()
    {
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            buttonCanvasGroup.alpha = alpha;
            yield return null;
        }

        buttonCanvasGroup.interactable = false; // Disable interactions with the button
        buttonCanvasGroup.blocksRaycasts = false; // Disable raycast blocking on the button
        gameObject.SetActive(false); // Disable the button game object
    }
}

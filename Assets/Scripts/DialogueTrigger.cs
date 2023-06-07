using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public CanvasGroup buttonCanvasGroup;
    public float fadeDuration = 0.3f;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        StartCoroutine(FadeButton());
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

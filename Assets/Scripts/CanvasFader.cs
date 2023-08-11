using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFader : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration of the fading animation
    public CanvasGroup canvasGroup; // Reference to the CanvasGroup component

    private void Start()
    {
        StartCoroutine(FadeInCanvas());
    }

    private IEnumerator FadeInCanvas()
    {
        float startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            float t = (Time.time - startTime) / fadeDuration;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            yield return null;
        }

        canvasGroup.alpha = 1f; // Ensure the panel is fully visible
        canvasGroup.interactable = true; // Enable interaction with the UI
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelFade : MonoBehaviour
{
    [SerializeField]
    private Image panelImage; // Reference to the Image component of your panel

    [SerializeField]
    private float fadeInDuration = 5f; // Duration of the fade-in in seconds

    [SerializeField]
    private float fadeOutDuration = 5f; // Duration of the fade-out in seconds

    [SerializeField]
    private float waitDuration = 5f; // Duration to wait between fade-in and fade-out in seconds

    [SerializeField]
    private int repeatCount = 2; // Number of times to repeat the fade-in and fade-out process

    private void Start()
    {
        StartCoroutine(RepeatFadeProcess());
    }

    private IEnumerator RepeatFadeProcess()
    {
        for (int i = 0; i < repeatCount; i++)
        {
            yield return StartCoroutine(FadeIn()); // Execute the fade-in process

            yield return new WaitForSeconds(waitDuration); // Wait for the specified wait duration

            yield return StartCoroutine(FadeOut()); // Execute the fade-out process
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color startColor = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0f); // Start color with alpha = 0
        Color targetColor = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0.95f); // Target color with alpha = 1

        while (elapsedTime < fadeInDuration)
        {
            float t = elapsedTime / fadeInDuration; // Calculate the normalized time value between 0 and 1
            panelImage.color = Color.Lerp(startColor, targetColor, t); // Interpolate the color with the current time value

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panelImage.color = targetColor; // Ensure the final color is set to the target color
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0.95f); // Start color with alpha = 1
        Color targetColor = new Color(panelImage.color.r, panelImage.color.g, panelImage.color.b, 0f); // Target color with alpha = 0

        while (elapsedTime < fadeOutDuration)
        {
            float t = elapsedTime / fadeOutDuration; // Calculate the normalized time value between 0 and 1
            panelImage.color = Color.Lerp(startColor, targetColor, t); // Interpolate the color with the current time value

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panelImage.color = targetColor; // Ensure the final color is set to the target color
    }
}

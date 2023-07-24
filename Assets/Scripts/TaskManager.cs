using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public float fadeInDuration = 1.0f; // Duration of the fade-in animation in seconds
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI task;
    public TextMeshProUGUI taskZero;

    private float currentTime = 0f;
    private bool isFading = false;

    void Start()
    {
        // Initialize the Panel and TextMeshPro text to be transparent
        canvasGroup.alpha = 0f;
        task.alpha = 0f;
        taskZero.alpha = 0f;
    }

    void Update()
    {
        // Check if the fade-in animation is active
        if (isFading)
        {
            currentTime += Time.deltaTime;

            // Calculate the current alpha value (transparency) based on the fade-in duration
            float alpha = Mathf.Clamp01(currentTime / fadeInDuration);

            // Set the alpha value for both the Panel and TextMeshPro text
            canvasGroup.alpha = alpha;
            task.alpha = alpha;
            taskZero.alpha = alpha;

            // Check if the fade-in animation is complete
            if (currentTime >= fadeInDuration)
            {
                isFading = false;
            }
        }
    }

    public void StartFadeIn()
    {
        // Start the fade-in animation
        currentTime = 0f;
        isFading = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextButtonTwo : MonoBehaviour
{
    public Button nextButton;
    public Button crouchButton;
    public Button standButton;
    public Button liftButton;
    public Button stairsButton;
    public Button checkButton;
    public Toggle toggleOne;
    public Toggle toggleTwo;
    public Toggle toggleThree;
    public TextMeshProUGUI secondQuestion;
    public TextMeshProUGUI thirdQuestion;
    private bool isButtonClicked = false;


    void Start()
    {
        nextButton.onClick.AddListener(OnFirstButtonClick);
    }

    void OnFirstButtonClick()
    {
        if (!isButtonClicked)
        {
            isButtonClicked = true;

            // Deactivate question
            secondQuestion.gameObject.SetActive(false);

            // Deactivate all 4 buttons
            crouchButton.gameObject.SetActive(false);
            standButton.gameObject.SetActive(false);
            liftButton.gameObject.SetActive(false);
            stairsButton.gameObject.SetActive(false);

            // Fade in Q3
            StartCoroutine(FadeInText(thirdQuestion));

            // Fade in 4 buttons
            StartCoroutine(FadeInToggle(toggleOne));
            StartCoroutine(FadeInToggle(toggleTwo));
            StartCoroutine(FadeInToggle(toggleThree));
            StartCoroutine(FadeInButton(checkButton));

            // Fade out and deactivate next button
            StartCoroutine(FadeButton(nextButton));
        }
    }

    private IEnumerator FadeInText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        Color originalColor = text.color;
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        float fadeDuration = 0.1f; // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.color = originalColor;
    }

    private IEnumerator FadeInButton(Button button)
    {
        button.gameObject.SetActive(true);

        // Get the RawImage component attached to the button
        RawImage buttonImage = button.GetComponent<RawImage>();
        if (buttonImage != null)
        {
            Color originalColor = buttonImage.color;

            float fadeDuration = 0.1f; // Adjust the duration as per your preference
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            buttonImage.color = originalColor;
        }

        button.interactable = true; // Enable the button after fading in
    }

    private IEnumerator FadeInToggle(Toggle toggle)
    {
        toggle.gameObject.SetActive(true);

        // Get the Image component attached to the toggle
        Image toggleImage = toggle.GetComponent<Image>();
        if (toggleImage != null)
        {
            Color originalColor = toggleImage.color;

            float fadeDuration = 0.1f; // Adjust the duration as per your preference
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
                toggleImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            toggleImage.color = originalColor;
        }

        toggle.interactable = true; // Enable the toggle after fading in
    }

    private IEnumerator FadeButton(Button button)
    {
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        Color originalColor = buttonText.color;

        float fadeDuration = 0.2f; // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            buttonText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Wait for the fade duration to complete
        yield return new WaitForSeconds(fadeDuration);

        // Deactivate the button gameObject after fading
        button.gameObject.SetActive(false);
    }

}

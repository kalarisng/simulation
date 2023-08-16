using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterButton : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button enterButton;
    public TextMeshProUGUI correctAnswer;
    public TextMeshProUGUI wrongAnswer;
    public bool enterButtonPressed = false;
    public GameObject exitUI;

    private void Start()
    {
        // Attach the CheckAnswer method to the Check Button's onClick event
        enterButton.onClick.AddListener(CheckAnswer);
    }

    public void CheckAnswer()
    {
        string userInput = inputField.text.ToLower();

        if (userInput.Contains("groceries") && userInput.Contains("supermarket"))
        {
            Debug.Log("Correct! The answer contains both 'groceries' and 'supermarket'.");
            enterButtonPressed = true;
            StartCoroutine(FadeInText(correctAnswer));
            StartCoroutine(FadeOutInputField(inputField));
            StartCoroutine(FadeOutButton(enterButton));
            exitUI.SetActive(true);
        }
        else
        {
            Debug.Log("Incorrect. The answer should contain both 'groceries' and 'supermarket'.");
            enterButtonPressed = true;
            StartCoroutine(FadeInText(wrongAnswer));
            StartCoroutine(FadeOutInputField(inputField));
            StartCoroutine(FadeOutButton(enterButton));
            exitUI.SetActive(true);
        }
    }

    private IEnumerator FadeInText(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        Color originalColor = text.color;
        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        float fadeDuration = 0.2f; // Adjust the duration as per your preference
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

    private IEnumerator FadeOutInputField(TMP_InputField inputField)
    {
        ColorBlock originalColors = inputField.colors;
        Color originalTextColor = inputField.textComponent.color;

        float fadeDuration = 0.2f; // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            originalColors.normalColor = new Color(originalColors.normalColor.r, originalColors.normalColor.g, originalColors.normalColor.b, alpha);
            originalColors.highlightedColor = new Color(originalColors.highlightedColor.r, originalColors.highlightedColor.g, originalColors.highlightedColor.b, alpha);
            inputField.colors = originalColors;
            inputField.textComponent.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Wait for the fade duration to complete
        yield return new WaitForSeconds(fadeDuration);

        // Deactivate the InputField gameObject after fading
        inputField.gameObject.SetActive(false);
    }

    private IEnumerator FadeOutButton(Button button)
    {
        ColorBlock originalColors = button.colors;
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        Color originalTextColor = buttonText.color;

        float fadeDuration = 0.2f; // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            originalColors.normalColor = new Color(originalColors.normalColor.r, originalColors.normalColor.g, originalColors.normalColor.b, alpha);
            originalColors.highlightedColor = new Color(originalColors.highlightedColor.r, originalColors.highlightedColor.g, originalColors.highlightedColor.b, alpha);
            button.colors = originalColors;
            buttonText.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Wait for the fade duration to complete
        yield return new WaitForSeconds(fadeDuration);

        // Deactivate the button gameObject after fading
        button.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecondNextButton : MonoBehaviour
{
    public Button secondNextButton;
    public Button checkButton;
    public TextMeshProUGUI secondQuestion;
    public TextMeshProUGUI thirdQuestion;
    public TextMeshProUGUI phoneButtonStat;
    public Toggle firstChoiceToggle;
    public Toggle secondChoiceToggle;
    public Toggle thirdChoiceToggle;


    public void OnSecondNextButtonClick()
    {
        StartCoroutine(PerformNextButtonActions());
    }

    private IEnumerator PerformNextButtonActions()
    {
        // disable the second question
        StartCoroutine(FadeOutText(secondQuestion));
        StartCoroutine(FadeOutText(phoneButtonStat));

        // enable the third question
        StartCoroutine(FadeInText(thirdQuestion));
        // enable the MCQ buttons
        firstChoiceToggle.gameObject.SetActive(true);
        secondChoiceToggle.gameObject.SetActive(true);
        thirdChoiceToggle.gameObject.SetActive(true);
        checkButton.gameObject.SetActive(true);

        // Wait for all coroutines to finish
        yield return new WaitForSeconds(0.3f);
        secondNextButton.interactable = false;
        secondNextButton.gameObject.SetActive(false);
    }
    private IEnumerator FadeButton(Button button)
    {
        // Fade out the button by reducing its alpha value gradually
        Image buttonImage = button.GetComponent<Image>();
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        Color originalColor = buttonImage.color;

        float fadeDuration = 0.2f;  // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Deactivate the button gameObject after fading
        button.gameObject.SetActive(false);
    }

    private IEnumerator FadeInButton(Button button)
    {
        button.gameObject.SetActive(true);
        Image buttonImage = button.GetComponent<Image>();
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        Color originalColor = buttonImage.color;
        Color originalTextColor = buttonText.color;

        float fadeDuration = 0.1f; // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            buttonText.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        buttonImage.color = originalColor;
        buttonText.color = originalTextColor;
        button.interactable = true; // Activate the button after fading in
    }


    private IEnumerator FadeOutText(TextMeshProUGUI text)
    {
        Color originalColor = text.color;

        float fadeDuration = 0.1f; // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Set alpha to 0 at the end of fading
        text.gameObject.SetActive(false); // Deactivate the TextMeshProUGUI object after fading
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

    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}

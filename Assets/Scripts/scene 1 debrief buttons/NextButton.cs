using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextButton : MonoBehaviour
{
    public Button phoneButton;
    public Button leftButton;
    public Button centerButton;
    public Button rightButton;
    public GameObject clickMe;
    public TextMeshProUGUI firstQuestion;
    public TextMeshProUGUI firstButtonStat;
    public TextMeshProUGUI secondButtonStat;
    public TextMeshProUGUI thirdButtonStat;
    public TextMeshProUGUI secondQuestion;

    public void OnNextButtonClick()
    {
        // Fade out all active buttons
        if (leftButton.interactable == true)
        {
            StartCoroutine(FadeButton(leftButton));
        }
        else if (centerButton.interactable == true)
        {
            StartCoroutine(FadeButton(centerButton));
        }
        else
        {
            StartCoroutine(FadeButton(centerButton));
        }

        // fade out stats text
        if (firstButtonStat.enabled == true)
        {
            StartCoroutine(FadeOutText(firstButtonStat));
        }
        else if (secondButtonStat.enabled == true)
        {
            StartCoroutine(FadeOutText(secondButtonStat));
        }
        else
        {
            StartCoroutine(FadeOutText(thirdButtonStat));
        }

        // disable the first question
        firstQuestion.gameObject.SetActive(false);
        // enable the second question
        StartCoroutine(FadeInText(secondQuestion));
        // enable the phone button
        StartCoroutine(FadeInButton(phoneButton));
        clickMe.gameObject.SetActive(true);
    }
    private IEnumerator FadeButton(Button button)
    {
        // Fade out the button by reducing its alpha value gradually
        Image buttonImage = button.GetComponent<Image>();
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        Color originalColor = buttonImage.color;

        float fadeDuration = 0.3f;  // Adjust the duration as per your preference
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

        float fadeDuration = 0.3f; // Adjust the duration as per your preference
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

        float fadeDuration = 0.3f; // Adjust the duration as per your preference
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

        float fadeDuration = 0.3f; // Adjust the duration as per your preference
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

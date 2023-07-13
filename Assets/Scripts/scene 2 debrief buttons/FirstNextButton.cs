using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstNextButton : MonoBehaviour
{
    public Button nextButton;
    public TextMeshProUGUI firstQuestion;
    public Button firstAnswerButton;
    public Button secondAnswerButton;
    public Button thirdAnswerButton;

    public TextMeshProUGUI firstFeedback;
    public TextMeshProUGUI firstAnswer;
    public TextMeshProUGUI secondQuestion;
    public Button crouchButton;
    public Button standButton;
    public Button liftButton;
    public Button stairsButton;

    private bool isButtonClicked = false; // Flag to track if the first button is clicked

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
            firstQuestion.gameObject.SetActive(false);

            // Deactivate all previous buttons
            firstAnswerButton.gameObject.SetActive(false);
            secondAnswerButton.gameObject.SetActive(false);
            thirdAnswerButton.gameObject.SetActive(false);

            // Deactivate answer or feedback text
            if (firstFeedback.gameObject.activeSelf)
            {
                firstFeedback.gameObject.SetActive(false);
            }
            else
            {
                firstAnswer.gameObject.SetActive(false);
            }

            // Fade in Q2 question
            StartCoroutine(FadeInText(secondQuestion));

            // Fade in 4 buttons
            StartCoroutine(FadeInButton(crouchButton));
            StartCoroutine(FadeInButton(standButton));
            StartCoroutine(FadeInButton(liftButton));
            StartCoroutine(FadeInButton(stairsButton));

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

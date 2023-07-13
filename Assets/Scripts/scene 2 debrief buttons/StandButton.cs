using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StandButton : MonoBehaviour
{
    public Button standButton;
    public TextMeshProUGUI buttonText;
    public RawImage image;
    public TextMeshProUGUI answer;
    public Button nextButton;

    private bool isButtonClicked = false; // Flag to track if the first button is clicked

    // Start is called before the first frame update
    void Start()
    {
        standButton.onClick.AddListener(OnFirstButtonClick);
    }

    void OnFirstButtonClick()
    {
        if (!isButtonClicked)
        {
            isButtonClicked = true;

            // Change the color of the button to green
            standButton.image.color = Color.green;
            buttonText = standButton.GetComponentInChildren<TextMeshProUGUI>();
            image = standButton.GetComponentInChildren<RawImage>();
            buttonText.gameObject.SetActive(false);
            image.gameObject.SetActive(false);

            StartCoroutine(FadeInText(answer));
            if (!nextButton.gameObject.activeSelf)
            {
                StartCoroutine(FadeInButton(nextButton));
            }
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
        TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
        Color originalColor = buttonText.color;
        buttonText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

        float fadeDuration = 0.2f; // Adjust the duration as per your preference
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            buttonText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Wait for the fade duration to complete
        yield return new WaitForSeconds(fadeDuration);

        // Activate the button after fading
        button.gameObject.SetActive(true);
    }
}

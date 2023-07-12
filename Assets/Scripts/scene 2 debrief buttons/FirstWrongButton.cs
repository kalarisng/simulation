using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstWrongButton : MonoBehaviour
{
    public Button firstButton;
    public Button nextButton;
    public Button[] fadeButtons;
    public TextMeshProUGUI answer;

    private bool isButtonClicked = false; // Flag to track if the first button is clicked

    // Start is called before the first frame update
    void Start()
    {
        firstButton.onClick.AddListener(OnFirstButtonClick);
    }

    void OnFirstButtonClick()
    {
        if (!isButtonClicked)
        {
            isButtonClicked = true;

            // Change the color of the first button to red
            firstButton.image.color = Color.red;
            StartCoroutine(FadeInText(answer));
            StartCoroutine(FadeInButton(nextButton));

            // Fade out the other buttons
            foreach (Button button in fadeButtons)
            {
                button.interactable = false;
                ColorBlock fadeColors = button.colors;
                fadeColors.disabledColor = new Color(fadeColors.disabledColor.r, fadeColors.disabledColor.g, fadeColors.disabledColor.b, 0f);
                button.colors = fadeColors;
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
}


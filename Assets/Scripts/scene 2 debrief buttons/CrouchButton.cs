using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrouchButton : MonoBehaviour
{
    public Button crouchButton;
    public TextMeshProUGUI buttonText;
    public RawImage image;
    public TextMeshProUGUI answer;

    private bool isButtonClicked = false; // Flag to track if the first button is clicked

    // Start is called before the first frame update
    void Start()
    {
        crouchButton.onClick.AddListener(OnFirstButtonClick);
    }

    void OnFirstButtonClick()
    {
        if (!isButtonClicked)
        {
            isButtonClicked = true;

            // Change the color of the button to green
            crouchButton.image.color = Color.green;
            buttonText = crouchButton.GetComponentInChildren<TextMeshProUGUI>();
            image = crouchButton.GetComponentInChildren<RawImage>();
            buttonText.gameObject.SetActive(false);
            image.gameObject.SetActive(false);

            StartCoroutine(FadeInText(answer));
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
}

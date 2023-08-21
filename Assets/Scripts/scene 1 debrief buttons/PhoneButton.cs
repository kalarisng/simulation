using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhoneButton : MonoBehaviour
{
    public Button phoneButton;
    public Button secondNextButton;
    public GameObject clickMe;
    public TextMeshProUGUI phoneButtonStat;

    public void OnPhoneButtonClick()
    {
        // fade out button
        clickMe.gameObject.SetActive(false);

        // StartCoroutine(FadeButton(phoneButton));
        phoneButton.gameObject.SetActive(false);

        // enable phone stat
        phoneButtonStat.gameObject.SetActive(true);
        secondNextButton.gameObject.SetActive(true);

        phoneButton.gameObject.SetActive(false);
    }

    private IEnumerator FadeButton(Button button)
    {
        // Get the RawImage component attached to the button
        RawImage buttonImage = button.GetComponent<RawImage>();
        if (buttonImage != null)
        {
            Color originalColor = buttonImage.color;

            float fadeDuration = 0.1f; // Adjust the duration as per your preference
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration)
            {
                float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
                buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }
    }

    // private IEnumerator FadeButton(Button button)
    // {
    //     // Fade out the button by reducing its alpha value gradually
    //     Image buttonImage = button.GetComponent<Image>();
    //     TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
    //     Color originalColor = buttonImage.color;

    //     float fadeDuration = 0.3f;  // Adjust the duration as per your preference
    //     float elapsedTime = 0f;

    //     while (elapsedTime < fadeDuration)
    //     {
    //         float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
    //         buttonImage.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
    //         buttonText.color = new Color(buttonText.color.r, buttonText.color.g, buttonText.color.b, alpha);

    //         elapsedTime += Time.deltaTime;
    //         yield return null;
    //     }

    //     // Deactivate the button gameObject after fading
    //     //button.gameObject.SetActive(false);
    // }
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThirdButton : MonoBehaviour
{
    public Animator animator;
    public Button leftButton;
    public Button centerButton;
    public Button rightButton;
    public Button nextButton;
    public TextMeshProUGUI textObject;

    private bool interactionCompleted = false;

    public void OnRightButtonClick()
    {
        if (!interactionCompleted)
        {
            animator.SetBool("isClicked", true);
            // Shift the center button to the left
            // rightButton.GetComponent<RectTransform>().anchoredPosition -= new Vector2(100f, 0f);

            // Fade out the left and right buttons
            StartCoroutine(FadeButton(leftButton));
            StartCoroutine(FadeButton(centerButton));

            // Show the text object
            textObject.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(true);

            interactionCompleted = true;
        }
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
    // Start is called before the first frame update
    // void Start()
    // {

    // }

    // // Update is called once per frame
    // void Update()
    // {

    // }
}

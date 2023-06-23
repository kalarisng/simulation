using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecondButton : MonoBehaviour
{
    public Animator animator;
    public Button[] buttons;
    public Button nextButton;
    public TextMeshProUGUI textObject;

    public void OnCenterButtonClick()
    {
        Debug.Log("Second Button clicked!");

        // Fade out the left and right buttons
        foreach (Button button in buttons)
        {
            StartCoroutine(FadeButton(button));
        }

        animator.SetBool("isClicked", true);

        // Show the text object
        textObject.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class CheckButtonThree : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Button checkButton;
    public TextMeshProUGUI buttonText;
    public GameObject debriefThreeCanvas;
    public GameObject exitUI;
    public GameObject openUI;
    [SerializeField]
    private RawImage starThree;
    private bool isAllCorrect = false;
    [SerializeField]
    private Canvas endOfGameCanvas;


    private void Start()
    {
        checkButton.onClick.AddListener(CheckToggles);
        checkButton.image.color = Color.yellow;
    }

    private void Update()
    {
        if (isAllCorrect)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                debriefThreeCanvas.SetActive(false);
                exitUI.SetActive(false);
                openUI.SetActive(false);
                starThree.gameObject.SetActive(true);
                endOfGameCanvas.gameObject.SetActive(true);
            }
        }
    }

    private System.Collections.IEnumerator FadeInRawImage(RawImage rawImage)
    {
        // Set the initial alpha value to 0
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 0f);

        // Enable the RawImage GameObject
        rawImage.gameObject.SetActive(true);

        // Gradually increase the alpha value over time
        float elapsedTime = 0f;
        while (elapsedTime < 1.0f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / 1.0f);
            rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha value is set to 1 when the fade-in is complete
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 1f);
    }

    private void CheckToggles()
    {
        if (toggle1.isOn && toggle2.isOn && toggle3.isOn)
        {
            checkButton.image.color = Color.green;
            isAllCorrect = true;
            buttonText.text = "Correct!";
            exitUI.SetActive(true);
        }
        else
        {
            checkButton.image.color = Color.red;
            buttonText.text = "Try again!";
        }
    }
}

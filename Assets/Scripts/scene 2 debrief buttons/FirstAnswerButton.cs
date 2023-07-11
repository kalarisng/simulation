using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FirstAnswerButton : MonoBehaviour
{
    public Button firstButton;
    public Button[] fadeButtons;
    public TextMeshProUGUI answer;
    // Start is called before the first frame update
    void Start()
    {
        firstButton.onClick.AddListener(() =>
        {
            // Change the color of the first button to red
            ColorBlock colors = firstButton.colors;
            colors.normalColor = Color.red;
            firstButton.colors = colors;

            // Fade out the other buttons
            foreach (Button button in fadeButtons)
            {
                button.interactable = false;
                ColorBlock fadeColors = button.colors;
                fadeColors.disabledColor = new Color(fadeColors.disabledColor.r, fadeColors.disabledColor.g, fadeColors.disabledColor.b, 0f);
                button.colors = fadeColors;
            }

            // Activate the text
            answer.gameObject.SetActive(true);
        });
    }
}

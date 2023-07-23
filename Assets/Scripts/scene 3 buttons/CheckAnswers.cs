using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckAnswers : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button checkButton;
    public TextMeshProUGUI wrongAnswer;
    public TextMeshProUGUI correctAnswer;

    public SelectedButtonsData selectedButtonsData;
    // Start is called before the first frame update
    void Start()
    {
        checkButton.onClick.AddListener(CheckAnswer);
    }

    // Update is called once per frame
    void CheckAnswer()
    {
        string userInput = inputField.text;
        // Split the string based on commas
        string[] words = userInput.Split(',');

        // Trim each word to remove leading and trailing spaces
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = words[i].Trim();
        }

        // Access the list of selected buttons in SelectedButtonsData
        List<FoodButton> selectedButtons = selectedButtonsData.selectedButtons;

        for (int j = 0; j < words.Length; j++)
        {
            bool wordMatched = true;
            foreach (FoodButton button in selectedButtons)
            {
                if (words[j] != button.name)
                {
                    Debug.Log(button.name);
                    wrongAnswer.gameObject.SetActive(true);
                    wordMatched = false;
                    break;
                }
            }

            if (wordMatched)
            {
                correctAnswer.gameObject.SetActive(true);
            }
        }
    }
}

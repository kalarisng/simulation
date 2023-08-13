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

    // Start is called before the first frame update
    void Start()
    {
        checkButton.onClick.AddListener(CheckAnswer);
    }

    // Method to check user's answer
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

        bool allWordsMatched = true;

        foreach (Button button in ButtonManager.selectedButtons)
        {
            bool wordMatched = false;

            foreach (string word in words)
            {
                if (word == button.name)
                {
                    wordMatched = true;
                    break;
                }
            }

            if (!wordMatched)
            {
                allWordsMatched = false;
                break;
            }
        }

        if (allWordsMatched && words.Length == ButtonManager.selectedButtons.Count)
        {
            correctAnswer.gameObject.SetActive(true);
            wrongAnswer.gameObject.SetActive(false);
        }
        else
        {
            correctAnswer.gameObject.SetActive(false);
            wrongAnswer.gameObject.SetActive(true);
        }
    }
}

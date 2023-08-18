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
    public TextMeshProUGUI attemptsText;
    public int maxAttempts = 3; // Maximum number of allowed attempts
    private int currentAttempts = 0; // Counter for attempts
    public Canvas dementiaCanvas;
    public GameObject exitUI;
    public GameObject boxThree;
    [SerializeField]
    private LivingRoomDoorLocationArrow livingRoomDoorLocationArrowScript;
    [SerializeField]
    private DebriefThreeLocationArrow debriefThreeLocationArrowScript;

    // Start is called before the first frame update
    void Start()
    {
        checkButton.onClick.AddListener(CheckAnswer);
        UpdateAttemptsText();
    }

    void Update()
    {
        if ((maxAttempts - currentAttempts) == 0)
        {
            exitUI.SetActive(true);
        }

        if ((maxAttempts - currentAttempts) == 0 && Input.GetKeyDown(KeyCode.X))
        {
            dementiaCanvas.gameObject.SetActive(false);
            exitUI.SetActive(false);
            boxThree.SetActive(true);
            livingRoomDoorLocationArrowScript.enabled = false;
            debriefThreeLocationArrowScript.enabled = true;
        }
    }

    // Method to check user's answer
    void CheckAnswer()
    {
        if (currentAttempts >= maxAttempts)
        {
            Debug.Log("No more attempts left.");
            return; // Prevent further checks if max attempts reached
        }

        currentAttempts++;
        UpdateAttemptsText();

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

    void UpdateAttemptsText()
    {
        attemptsText.text = "Attempts left: " + (maxAttempts - currentAttempts);
    }
}

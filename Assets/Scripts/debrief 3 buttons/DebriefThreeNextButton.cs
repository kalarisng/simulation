using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebriefThreeNextButton : MonoBehaviour
{
    public Button memoryLossButton;
    public Button confusionButton;
    public Button moodSwingButton;
    public Button cannotTalkButton;
    public Button nextButton;
    public TextMeshProUGUI firstQuestion;
    public TextMeshProUGUI memoryLossText;
    public TextMeshProUGUI confusionText;
    public TextMeshProUGUI moodSwingText;
    public TextMeshProUGUI cannotTalkText;
    public TextMeshProUGUI secondQuestion;
    public Button memoryImpairmentButton;
    public Button processingSpeedButton;
    public Button problemSolvingButton;
    public Button attentionSpanButton;

    public void OnNextButtonClick()
    {
        StartCoroutine(PerformNextButtonActions());
    }

    private IEnumerator PerformNextButtonActions()
    {
        // disable the first question
        firstQuestion.gameObject.SetActive(false);
        memoryLossButton.gameObject.SetActive(false);
        memoryLossText.gameObject.SetActive(false);
        confusionButton.gameObject.SetActive(false);
        confusionText.gameObject.SetActive(false);
        moodSwingButton.gameObject.SetActive(false);
        moodSwingText.gameObject.SetActive(false);
        cannotTalkButton.gameObject.SetActive(false);
        cannotTalkText.gameObject.SetActive(false);

        // enable the second question
        secondQuestion.gameObject.SetActive(true);

        memoryImpairmentButton.gameObject.SetActive(true);
        processingSpeedButton.gameObject.SetActive(true);
        problemSolvingButton.gameObject.SetActive(true);
        attentionSpanButton.gameObject.SetActive(true);

        nextButton.gameObject.SetActive(false);

        yield return null;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebriefThreeSecondNextButton : MonoBehaviour
{
    public TextMeshProUGUI secondQuestion;
    public Button memoryImpairmentButton;
    public Button processingSpeedButton;
    public Button problemSolvingButton;
    public Button attentionSpanButton;
    public Button secondNextButton;
    public RawImage memImpairmentTick;
    public RawImage procSpeedTick;
    public RawImage probSolvingTick;
    public RawImage attentionSpanTick;
    public TextMeshProUGUI thirdQuestion;
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Button checkButton;

    public void OnNextButtonClick()
    {
        StartCoroutine(PerformNextButtonActions());
    }

    private IEnumerator PerformNextButtonActions()
    {
        // disable the second question
        secondQuestion.gameObject.SetActive(false);
        memoryImpairmentButton.gameObject.SetActive(false);
        memImpairmentTick.gameObject.SetActive(false);
        processingSpeedButton.gameObject.SetActive(false);
        procSpeedTick.gameObject.SetActive(false);
        problemSolvingButton.gameObject.SetActive(false);
        probSolvingTick.gameObject.SetActive(false);
        attentionSpanButton.gameObject.SetActive(false);
        attentionSpanTick.gameObject.SetActive(false);

        // enable the third question
        thirdQuestion.gameObject.SetActive(true);
        toggle1.gameObject.SetActive(true);
        toggle2.gameObject.SetActive(true);
        toggle3.gameObject.SetActive(true);
        checkButton.gameObject.SetActive(true);

        secondNextButton.gameObject.SetActive(false);

        yield return null;
    }
}

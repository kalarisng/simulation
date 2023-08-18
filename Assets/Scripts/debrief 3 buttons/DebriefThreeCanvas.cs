using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebriefThreeCanvas : MonoBehaviour
{
    public TextMeshProUGUI memoryLossText;
    public TextMeshProUGUI confusionText;
    public TextMeshProUGUI moodSwingText;
    public TextMeshProUGUI cannotTalkText;
    public Button nextButton;
    public RawImage memImpairmentTick;
    public RawImage procSpeedTick;
    public RawImage probSolvingTick;
    public RawImage attentionSpanTick;
    public Button secondNextButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (memoryLossText.gameObject.activeSelf && confusionText.gameObject.activeSelf && moodSwingText.gameObject.activeSelf && cannotTalkText.gameObject.activeSelf)
        {
            nextButton.gameObject.SetActive(true);
        }
        else if (!memoryLossText.gameObject.activeSelf && !confusionText.gameObject.activeSelf && !moodSwingText.gameObject.activeSelf && !cannotTalkText.gameObject.activeSelf)
        {
            nextButton.gameObject.SetActive(false);
        }

        if (memImpairmentTick.gameObject.activeSelf && procSpeedTick.gameObject.activeSelf && probSolvingTick.gameObject.activeSelf && attentionSpanTick.gameObject.activeSelf)
        {
            secondNextButton.gameObject.SetActive(true);
        }
        else if (!memImpairmentTick.gameObject.activeSelf && !procSpeedTick.gameObject.activeSelf && !probSolvingTick.gameObject.activeSelf && !attentionSpanTick.gameObject.activeSelf)
        {
            secondNextButton.gameObject.SetActive(false);
        }
    }
}

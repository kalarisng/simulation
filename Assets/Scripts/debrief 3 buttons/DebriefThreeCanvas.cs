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
    }
}

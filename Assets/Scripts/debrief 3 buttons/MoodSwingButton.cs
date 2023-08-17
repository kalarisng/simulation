using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoodSwingButton : MonoBehaviour
{
    public TextMeshProUGUI moodSwingText;

    public void OnButtonClick()
    {
        moodSwingText.gameObject.SetActive(true);
    }
}

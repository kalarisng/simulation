using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConfusionButton : MonoBehaviour
{
    public TextMeshProUGUI confusionText;

    public void OnButtonClick()
    {
        confusionText.gameObject.SetActive(true);
    }
}

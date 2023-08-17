using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryLossButton : MonoBehaviour
{
    public TextMeshProUGUI memoryLossText;

    public void OnButtonClick()
    {
        memoryLossText.gameObject.SetActive(true);
    }
}

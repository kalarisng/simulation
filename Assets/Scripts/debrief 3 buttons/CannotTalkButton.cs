using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CannotTalkButton : MonoBehaviour
{
    public TextMeshProUGUI cannotTalkText;

    public void OnButtonClick()
    {
        cannotTalkText.gameObject.SetActive(true);
    }
}

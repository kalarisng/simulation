using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DebriefThreeNextButton : MonoBehaviour
{
    public GameObject firstQuestionPage;

    public void OnButtonClick()
    {
        firstQuestionPage.SetActive(false);
    }
}

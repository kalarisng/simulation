using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProbSolvingButton : MonoBehaviour
{
    public RawImage tick;

    public void OnButtonClick()
    {
        tick.gameObject.SetActive(true);
    }
}

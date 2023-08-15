using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class CheckButton : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Button checkButton;
    public TextMeshProUGUI buttonText;
    public Transform teleportDestination;
    public GameObject exitUI;
    public TextMeshProUGUI taskTwo;
    private bool isAnswerCorrect = false;
    [SerializeField]
    private Canvas debriefOneCanvas;
    [SerializeField]
    private RawImage starOne;
    public GameObject triggerDoorOpen;
    [SerializeField]
    private DebriefOneLocationArrow debriefOneLocationArrowScript;
    public GameObject callCollider;

    private void Start()
    {
        checkButton.onClick.AddListener(CheckToggles);
        checkButton.image.color = Color.yellow;
    }

    private void Update()
    {
        if (isAnswerCorrect && Input.GetKeyDown(KeyCode.X))
        {
            debriefOneCanvas.gameObject.SetActive(false);
            exitUI.SetActive(false);
            starOne.gameObject.SetActive(true);
            taskTwo.gameObject.SetActive(true);
            triggerDoorOpen.SetActive(true);
            debriefOneLocationArrowScript.enabled = false;
            callCollider.SetActive(false);
        }
    }

    private void CheckToggles()
    {
        if (toggle1.isOn && toggle2.isOn && toggle3.isOn)
        {
            checkButton.image.color = Color.green;
            buttonText.text = "Correct!";
            isAnswerCorrect = true;
            exitUI.SetActive(true);
        }
        else
        {
            checkButton.image.color = Color.red;
            buttonText.text = "Try again!";
        }
    }
}

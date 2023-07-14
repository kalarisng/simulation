using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;

public class CheckButtonTwo : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Button checkButton;
    public TextMeshProUGUI buttonText;
    public GameObject debriefTwoCanvas;
    public GameObject exitUI;
    public StarterAssetsInputs starterAssetsInputs;

    private void Start()
    {
        checkButton.onClick.AddListener(CheckToggles);
        checkButton.image.color = Color.yellow;
    }

    private void Update()
    {
        if (debriefTwoCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("Closing debrief two");
                debriefTwoCanvas.SetActive(false);
                exitUI.SetActive(false);
                // starterAssetsInputs.LockCharacterMovement(false);
            }
        }
    }

    private void CheckToggles()
    {
        if (toggle1.isOn && toggle2.isOn && toggle3.isOn)
        {
            checkButton.image.color = Color.green;
            buttonText.text = "Correct!";
            exitUI.SetActive(true);
        }
        else
        {
            checkButton.image.color = Color.red;
            buttonText.text = "Try again!";
        }
    }
}

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
    public GameObject debriefOneCanvas;
    public GameObject exitUI;
    public FirstPersonController firstPersonController; // Reference to the FirstPersonController component

    private void Start()
    {
        checkButton.onClick.AddListener(CheckToggles);
        checkButton.image.color = Color.yellow;
    }

    private void Update()
    {
        if (debriefOneCanvas.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Closing debrief one");
            debriefOneCanvas.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public static int maxSelectionCount = 5;

    public Button foodButton;
    public RawImage tick;
    public Canvas supermarketListCanvas; // Assign the panel in the Inspector
    public Canvas clicker;
    public GameObject exitUI;
    [SerializeField]
    private PhoneCallAudio phoneCallAudioScript;
    [SerializeField]
    private LivingRoomPhoneLocationArrow livingRoomPhoneLocationArrowScript;
    [SerializeField]
    private SelectFoodLocationArrow selectFoodLocationArrowScript;

    // Start is called before the first frame update
    void Start()
    {
        foodButton.onClick.AddListener(ToggleButton);
        ToggleButtonInteractivity();
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonManager.selectedButtons.Count == maxSelectionCount)
        {
            exitUI.SetActive(true);
        }
        if (ButtonManager.selectedButtons.Count < maxSelectionCount)
        {
            exitUI.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.X) && ButtonManager.selectedButtons.Count == maxSelectionCount)
        {
            supermarketListCanvas.gameObject.SetActive(false);
            exitUI.SetActive(false);
            clicker.gameObject.SetActive(true);
            selectFoodLocationArrowScript.enabled = false;
            livingRoomPhoneLocationArrowScript.enabled = true;
            phoneCallAudioScript.enabled = true;
        }
    }

    // Handle button selection
    public void ToggleButton()
    {
        if (tick.gameObject.activeSelf)
        {
            tick.gameObject.SetActive(false);
            ButtonManager.selectedButtons.Remove(foodButton);
        }
        else
        {
            if (ButtonManager.selectedButtons.Count < maxSelectionCount)
            {
                tick.gameObject.SetActive(true);
                ButtonManager.selectedButtons.Add(foodButton);
            }
        }

        // Disable or enable button clicks based on the selection count
        ToggleButtonInteractivity();
    }

    private void ToggleButtonInteractivity()
    {
        Button[] foodButtons = FindObjectsOfType<Button>();

        foreach (Button button in foodButtons)
        {
            if (ButtonManager.selectedButtons.Count >= maxSelectionCount && !ButtonManager.selectedButtons.Contains(button))
            {
                button.interactable = false;
            }
            else
            {
                button.interactable = true;
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public static int maxSelectionCount = 5;
    public static int minSelectionCount = 5;

    public Button foodButton;
    public RawImage tick;

    // Reference to the scriptable object to store selected buttons' data
    public SelectedButtonsData selectedButtonsData;

    // Start is called before the first frame update
    void Start()
    {
        foodButton.onClick.AddListener(Tick);
        ToggleButtonInteractivity();
    }

    // Handle button selection
    public void Tick()
    {
        if (tick.gameObject.activeSelf)
        {
            tick.gameObject.SetActive(false);
            selectedButtonsData.selectedButtons.Remove(this);
        }
        else
        {
            if (selectedButtonsData.selectedButtons.Count < maxSelectionCount)
            {
                tick.gameObject.SetActive(true);
                selectedButtonsData.selectedButtons.Add(this);
            }
        }

        // Disable or enable button clicks based on the selection count
        ToggleButtonInteractivity();
    }

    private void ToggleButtonInteractivity()
    {
        // Get all the FoodButton components in the scene
        FoodButton[] foodButtons = FindObjectsOfType<FoodButton>();

        // Iterate through each button and disable the click if the maximum selection count is reached
        foreach (FoodButton button in foodButtons)
        {
            Button buttonComponent = button.foodButton;
            if (selectedButtonsData.selectedButtons.Count >= maxSelectionCount && !button.tick.gameObject.activeSelf)
            {
                buttonComponent.interactable = false;
            }
            else
            {
                buttonComponent.interactable = true;
            }
        }
    }
}

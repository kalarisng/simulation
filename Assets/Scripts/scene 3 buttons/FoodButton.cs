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

    // Start is called before the first frame update
    void Start()
    {
        foodButton.onClick.AddListener(ToggleButton);
        ToggleButtonInteractivity();
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

        // Deactivate the panel if exactly 5 buttons are selected
        if (ButtonManager.selectedButtons.Count == maxSelectionCount && Input.GetKeyDown(KeyCode.X))
        {
            supermarketListCanvas.gameObject.SetActive(false);
        }
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

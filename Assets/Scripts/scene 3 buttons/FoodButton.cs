using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodButton : MonoBehaviour
{
    public static int maxSelectionCount = 5;

    public Button foodButton;
    public RawImage tick;

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SelectedButtonsData", menuName = "Selected Buttons Data")]
public class SelectedButtonsData : ScriptableObject
{
    public List<FoodButton> selectedButtons = new List<FoodButton>();
}


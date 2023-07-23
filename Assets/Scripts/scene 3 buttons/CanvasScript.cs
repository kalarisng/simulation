using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    // Reference to the SelectedButtonsData scriptable object
    public SelectedButtonsData selectedButtonsData;

    // Start is called before the first frame update
    void Start()
    {
        // Create an instance of the SelectedButtonsData scriptable object if it doesn't exist
        if (selectedButtonsData == null)
        {
            selectedButtonsData = ScriptableObject.CreateInstance<SelectedButtonsData>();
        }
    }
}

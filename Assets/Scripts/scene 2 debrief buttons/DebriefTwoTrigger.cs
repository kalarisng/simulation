using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class DebriefTwoTrigger : MonoBehaviour
{
    public Canvas debriefTwoCanvas;
    public StarterAssetsInputs starterAssetsInputs;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            starterAssetsInputs.LockCharacterMovement(true);
            // Activate the canvas
            debriefTwoCanvas.gameObject.SetActive(true);
        }
    }
}

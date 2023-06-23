using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoorInteraction : MonoBehaviour
{
    public GameObject canvasGameObject; // Reference to the canvas GameObject

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger collision is with the player capsule
        if (other.CompareTag("Player"))
        {
            // Enable the canvas
            canvasGameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the trigger collision is with the player capsule
        if (other.CompareTag("Player"))
        {
            // Disable the canvas
            canvasGameObject.SetActive(false);
        }
    }
}

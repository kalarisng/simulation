using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class ScreenFader : MonoBehaviour
{
    public float fadeDuration = 1f;
    public Image fadeImage;
    public Transform teleportDestination;
    public FirstPersonController playerController; // Reference to the FirstPersonController component

    public void FadeToBlackAndTeleport()
    {
        StartCoroutine(FadeCoroutine());
    }

    public System.Collections.IEnumerator FadeCoroutine()
    {
        fadeImage.color = Color.black;

        // Wait for the fade duration
        yield return new WaitForSeconds(fadeDuration);

        // Perform teleportation or other actions here
        TeleportToAnotherPlace();
        fadeImage.color = Color.clear;
    }

    private void TeleportToAnotherPlace()
    {
        if (teleportDestination != null)
        {
            // Teleport the player to the destination
            if (playerController != null)
            {
                playerController.enabled = false; // Disable the FirstPersonController before teleportation
                playerController.transform.position = teleportDestination.position; // Teleport the player to the destination
                playerController.enabled = true; // Enable the FirstPersonController after teleportation

                // Reset movement input after teleportation
                Debug.Log("Player movement resetted");
                playerController.GetComponent<StarterAssetsInputs>().MoveInput(Vector2.zero);
            }
        }
    }

}

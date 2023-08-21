using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField]
    private Animator myDoor = null;

    [SerializeField]
    private bool openTrigger = false;
    [SerializeField]
    private bool closeTrigger = false;
    public PlayerSceneOne playerSceneOneScript;
    public PlayerSceneTwo playerSceneTwoScript;
    private AudioSource audioSource; // Reference to the AudioSource component
    [SerializeField]
    private Canvas endOfSceneOneCanvas;
    [SerializeField]
    private Canvas clicker;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component from the same GameObject
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                Debug.Log("hit door open trigger");
                myDoor.Play("DoorOpen", 0, 0.0f);
                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.Play();
                    StartCoroutine(DeactivateColliderAfterAudioFinishes());
                }
                // gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                Debug.Log("hit door close trigger");
                myDoor.Play("DoorClose", 0, 0.0f);
                if (audioSource != null && audioSource.clip != null)
                {
                    audioSource.Play();
                    StartCoroutine(DeactivateColliderAfterAudioFinishes());
                }
                clicker.gameObject.SetActive(false);
                endOfSceneOneCanvas.gameObject.SetActive(true);
                // gameObject.SetActive(false);
                playerSceneOneScript.enabled = false;
                playerSceneTwoScript.enabled = true;
            }
        }
    }

    private System.Collections.IEnumerator DeactivateColliderAfterAudioFinishes()
    {
        // Wait for the audio clip to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Deactivate the collider after the audio is done playing
        gameObject.SetActive(false);
    }
}


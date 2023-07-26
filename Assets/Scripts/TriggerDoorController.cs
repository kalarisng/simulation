using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField]
    private Animator myDoor = null;

    [SerializeField]
    private bool openTrigger = false;
    [SerializeField]
    private bool closeTrigger = false;
    public PlayerSceneTwo playerSceneTwoScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (openTrigger)
            {
                Debug.Log("hit door open trigger");
                myDoor.Play("DoorOpen", 0, 0.0f);
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.Play();
                gameObject.SetActive(false);
            }
            else if (closeTrigger)
            {
                Debug.Log("hit door close trigger");
                myDoor.Play("DoorClose", 0, 0.0f);
                gameObject.SetActive(false);
                playerSceneTwoScript.enabled = true;
            }
        }
    }
}


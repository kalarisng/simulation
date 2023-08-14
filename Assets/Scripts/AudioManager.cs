using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioSources;
    public AudioTriplet[] audioClipTriplets; // Use a new custom class for triplets of AudioClips
    public Button[] buttons;
    public GameObject exitPanel;
    public Canvas phoneCanvas;
    private bool isAudioEnded = false;

    private void Start()
    {
        // Attach click events to the buttons
        for (int i = 0; i < audioSources.Length; i++)
        {
            int index = i;
            Button button = buttons[i];
            button.onClick.AddListener(() =>
            {
                PlayAudioTriplet(index); // Call the function for playing audio triplets
                HideOtherButtons(index);
            });
        }
    }

    private void Update()
    {
        if (isAudioEnded && Input.GetKeyDown(KeyCode.X))
        {
            phoneCanvas.gameObject.SetActive(false);
        }
    }

    private void PlayAudioTriplet(int index)
    {
        if (index >= 0 && index < audioClipTriplets.Length)
        {
            AudioTriplet audioTriplet = audioClipTriplets[index];

            audioSources[index].clip = audioTriplet.firstClip;
            audioSources[index].Play();

            float delay1 = audioTriplet.firstClip.length;
            float delay2 = delay1 + audioTriplet.secondClip.length;
            float delay3 = delay2 + audioTriplet.thirdClip.length;

            Invoke("PlaySecondAudioClip", delay1);
            Invoke("PlayThirdAudioClip", delay2);
            Invoke("ActivateExitPanel", delay3);
        }
    }

    private void PlaySecondAudioClip()
    {
        int index = GetCurrentButtonIndex();
        AudioTriplet audioTriplet = audioClipTriplets[index];

        audioSources[index].clip = audioTriplet.secondClip;
        audioSources[index].Play();
    }

    private void PlayThirdAudioClip()
    {
        int index = GetCurrentButtonIndex();
        AudioTriplet audioTriplet = audioClipTriplets[index];

        audioSources[index].clip = audioTriplet.thirdClip;
        audioSources[index].Play();
    }

    private void ActivateExitPanel()
    {
        isAudioEnded = true;
        exitPanel.SetActive(true);
    }

    private int GetCurrentButtonIndex()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].gameObject.activeSelf)
            {
                return i;
            }
        }
        return -1; // No active button found
    }

    private void HideOtherButtons(int visibleIndex)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(i == visibleIndex);
        }
    }
}

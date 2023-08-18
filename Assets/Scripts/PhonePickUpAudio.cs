using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePickUpAudio : MonoBehaviour
{
    public AudioClip firstAudioClip;  // Assign your first audio clip in the Inspector
    public AudioClip audioClip1;      // Assign your first concurrent audio clip in the Inspector
    public AudioClip audioClip2;      // Assign your second concurrent audio clip in the Inspector
    public AudioClip lastAudioClip;

    private AudioSource audioSource;
    public bool isPhoneCallDone = false;
    public GameObject exitUI;
    public GameObject pickUpUI;
    [SerializeField]
    private Canvas telephoneCanvas;
    [SerializeField]
    private LivingRoomPhoneLocationArrow livingRoomPhoneLocationArrowScript;
    [SerializeField]
    private LivingRoomDoorLocationArrow livingRoomDoorLocationArrowScript;

    // Start is called before the first frame update
    void Start()
    {
        pickUpUI.SetActive(false);

        audioSource = GetComponent<AudioSource>();

        StartCoroutine(PlaySequentialAndConcurrentAudio());
    }

    IEnumerator PlaySequentialAndConcurrentAudio()
    {
        // Play the first audio clip
        audioSource.clip = firstAudioClip;
        audioSource.Play();

        // Wait until the first audio clip finishes playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Calculate the loop count based on the ratio of audioClip1's length to audioClip2's length
        int loopCount = Mathf.CeilToInt(audioClip2.length / audioClip1.length);

        // Create and configure an AudioSource for concurrent audio
        AudioSource audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource1.clip = audioClip1;

        // Play the shorter audio clip looped
        audioSource1.loop = true;
        audioSource1.Play();

        // Create and configure an AudioSource for the second concurrent audio clip
        AudioSource audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.clip = audioClip2;

        // Play the second concurrent audio clip
        audioSource2.Play();

        // Wait until the second concurrent audio clip finishes playing
        yield return new WaitForSeconds(audioClip2.length);

        // Stop and clean up the additional AudioSources
        audioSource1.loop = false;
        audioSource1.Stop();
        Destroy(audioSource1);
        Destroy(audioSource2);

        // Play the last audio clip
        audioSource.clip = lastAudioClip;
        audioSource.Play();

        StartCoroutine(WaitForAudioToEnd());

        Debug.Log("All audio clips have finished playing.");
    }

    private IEnumerator WaitForAudioToEnd()
    {
        // Wait until the audio is done playing
        while (audioSource.isPlaying)
        {
            yield return null; // Wait for the next frame
        }

        // Set the boolean once the audio is done
        isPhoneCallDone = true;
    }


    void Update()
    {
        if (isPhoneCallDone)
        {
            exitUI.SetActive(true);
        }
        if (isPhoneCallDone && Input.GetKeyDown(KeyCode.X))
        {
            exitUI.SetActive(false);
            telephoneCanvas.gameObject.SetActive(false);
            livingRoomPhoneLocationArrowScript.enabled = false;
            livingRoomDoorLocationArrowScript.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCollider : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger involves the box collider
        if (other.CompareTag("Player")) // Replace with your tag or comparison method
        {
            // Play the collision audio
            audioSource.Play();
        }
    }
}

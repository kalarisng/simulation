using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DaughterButton : MonoBehaviour
{
    public Button[] buttons;  // Array to store references to the buttons
    public TextMeshProUGUI timestamp;
    public TextMeshProUGUI contact;
    public RawImage searchBar;
    public GameObject dialPage;
    public void OnButtonClick()
    {
        Debug.Log("Daughter button clicked!");
        contact.gameObject.SetActive(false);
        searchBar.gameObject.SetActive(false);

        // Loop through the buttons and fade them away
        foreach (Button button in buttons)
        {
            // StartCoroutine(FadeButton(button));
            button.gameObject.SetActive(false);
        }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
        audioSource.Play();

        // Set the dial page to be visible
        dialPage.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerSceneThree : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    private GameObject exitUI;

    [SerializeField]
    private Canvas supermarketListCanvas;

    [SerializeField]
    public Canvas clicker;

    [SerializeField]
    [Min(1)]
    private float hitRange = 1;
    [SerializeField]
    private GameObject inHandItem;

    private RaycastHit hit;
    public EnterButton enterButtonScript;
    [SerializeField]
    private Canvas taskQuestionCanvas;
    [SerializeField]
    private PlayerSceneTwo playerSceneTwoScript;
    [SerializeField]
    private GameObject taskQuestionCollider;
    [SerializeField]
    private GameObject phoneCallSound;
    private AudioSource phoneAudioSource;
    private int loopCount = 3;
    [SerializeField]
    private SelectFoodLocationArrow selectFoodLocationArrowScript;

    private void Start()
    {
        playerSceneTwoScript.enabled = false;
        selectFoodLocationArrowScript.enabled = true;
        phoneAudioSource = phoneCallSound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }
        if (inHandItem != null)
        {
            return;
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            if (hit.collider.GetComponent<SupermarketList>())
            {
                Debug.Log("Hit supermarket list");
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    clicker.gameObject.SetActive(false);
                    supermarketListCanvas.gameObject.SetActive(true);
                }

                if (supermarketListCanvas.gameObject.activeSelf)
                {
                    pickUpUI.SetActive(false);
                    exitUI.SetActive(true);
                }

                if (supermarketListCanvas.gameObject.activeSelf && Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("Closing task paper UI");
                    clicker.gameObject.SetActive(true);
                    supermarketListCanvas.gameObject.SetActive(false);
                    exitUI.SetActive(false);
                    for (int i = 0; i < loopCount; i++)
                    {
                        phoneAudioSource.Play();
                        while (phoneAudioSource.isPlaying)
                        {
                            // Do nothing and wait
                        }
                    }
                }
            }
        }

        if (enterButtonScript.enterButtonPressed && Input.GetKeyDown(KeyCode.X))
        {
            taskQuestionCanvas.gameObject.SetActive(false);
            taskQuestionCollider.SetActive(false);
        }
    }
}

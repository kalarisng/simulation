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
    private GameObject pickUpPhoneUI;

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
    private int loopCount = 3;
    [SerializeField]
    private SelectFoodLocationArrow selectFoodLocationArrowScript;
    [SerializeField]
    private PhoneCallAudio phoneCallAudioScript;
    [SerializeField]
    private PhonePickUpAudio phonePickUpAudioScript;
    [SerializeField]
    private Canvas telephoneCanvas;
    [SerializeField]
    private LivingRoomPhoneLocationArrow livingRoomPhoneLocationArrowScript;
    [SerializeField]
    private LivingRoomDoorLocationArrow livingRoomDoorLocationArrowScript;
    [SerializeField]
    private GameObject openUI;
    [SerializeField]
    private Canvas debriefThreeCanvas;

    private void Start()
    {
        playerSceneTwoScript.enabled = false;
        selectFoodLocationArrowScript.enabled = true;
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
            pickUpPhoneUI.SetActive(false);
            openUI.SetActive(false);
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
            }
            if (hit.collider.GetComponent<LivingRoomPhone>())
            {
                Debug.Log("Hit living room phone");
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpPhoneUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    pickUpPhoneUI.SetActive(false);
                    telephoneCanvas.gameObject.SetActive(true);
                    phoneCallAudioScript.StopAudio();
                    phonePickUpAudioScript.enabled = true;
                }
                // if (phonePickUpAudioScript.isPhoneCallDone && telephoneCanvas.gameObject.activeSelf && Input.GetKeyDown(KeyCode.X))
                // {
                //     telephoneCanvas.gameObject.SetActive(false);
                //     livingRoomPhoneLocationArrowScript.enabled = false;
                //     livingRoomDoorLocationArrowScript.enabled = true;
                //     exitUI.SetActive(false);
                // }
            }
            if (hit.collider.GetComponent<Box>())
            {
                Debug.Log("Hit box 3");
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                openUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.O))
                {
                    openUI.SetActive(false);
                    debriefThreeCanvas.gameObject.SetActive(true);
                }
            }
        }

        if (enterButtonScript.enterButtonPressed && Input.GetKeyDown(KeyCode.X))
        {
            exitUI.SetActive(false);
            taskQuestionCanvas.gameObject.SetActive(false);
            taskQuestionCollider.SetActive(false);
        }
    }
}

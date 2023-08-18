using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerSceneOne : MonoBehaviour
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
    private GameObject taskPaperUI;

    [SerializeField]
    private Canvas phoneUI;

    [SerializeField]
    public Canvas clicker;

    [SerializeField]
    [Min(1)]
    private float hitRange = 1;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;

    private RaycastHit hit;
    [SerializeField]
    private TaskPaperLocationArrow taskPaperLocationArrowScript;
    [SerializeField]
    private PhoneLocationArrow phoneLocationArrowScript;
    private bool isTaskPaperRead = false;
    private bool isPhoneRead = false;
    public TaskManager taskManagerScript;
    public Canvas debriefOneCanvas;
    public GameObject openUI;
    public GameObject callCollider;

    private void Start()
    {
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
            openUI.SetActive(false);
        }
        if (inHandItem != null)
        {
            return;
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            if (hit.collider.GetComponent<TaskPaper>())
            {
                Debug.Log("Hit task paper");
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    clicker.gameObject.SetActive(false);
                    ReadObject(hit.collider.gameObject);
                }

                if (taskPaperUI.activeSelf)
                {
                    Debug.Log("Paper active, closing pick up UI");
                    pickUpUI.SetActive(false);
                    exitUI.SetActive(true);
                }

                if (taskPaperUI.activeSelf && Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("Closing task paper UI");
                    taskManagerScript.StartFadeIn();
                    clicker.gameObject.SetActive(true);
                    taskPaperUI.SetActive(false);
                    exitUI.SetActive(false);
                    phoneLocationArrowScript.enabled = true;
                }
            }

            if (isTaskPaperRead)
            {
                if (hit.collider.GetComponent<Phone>())
                {
                    Debug.Log("Hit phone");
                    hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                    pickUpUI.SetActive(true);

                    if (callCollider.activeSelf)
                    {
                        callCollider.SetActive(false);
                    }

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        clicker.gameObject.SetActive(false);
                        ReadObject(hit.collider.gameObject);
                    }

                    if (phoneUI.gameObject.activeSelf)
                    {
                        pickUpUI.SetActive(false);
                    }
                }
            }

            if (isPhoneRead)
            {
                if (hit.collider.GetComponent<Box>())
                {
                    Debug.Log("Hit box");
                    hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                    openUI.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        openUI.SetActive(false);
                        debriefOneCanvas.gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    void ReadObject(GameObject obj)
    {
        if (obj.name == "A4_Lined_Paper_FBX")
        {
            Debug.Log("Read object: " + obj.name);
            taskPaperUI.SetActive(true);
            taskPaperLocationArrowScript.enabled = false;
            isTaskPaperRead = true;
            // MouseLook.paperActive = true;
        }

        if (obj.name == "smartphone")
        {
            Debug.Log("Read object: " + obj.name);
            phoneUI.gameObject.SetActive(true);
            phoneLocationArrowScript.enabled = false;
            isPhoneRead = true;
            // MouseLook.paperActive = true;
        }
    }
}

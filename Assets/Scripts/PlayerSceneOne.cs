using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    private GameObject contactPaperUI;

    [SerializeField]
    private GameObject contactDialogueBox;

    [SerializeField]
    public Canvas clicker;

    [SerializeField]
    [Min(1)]
    private float hitRange = 1;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;

    [SerializeField]
    private InputActionReference interactionInput, dropInput, useInput;

    private RaycastHit hit;
    [SerializeField]
    private TaskPaperLocationArrow taskPaperLocationArrowScript;
    [SerializeField]
    private ContactPaperLocationArrow contactPaperLocationArrowScript;
    [SerializeField]
    private Canvas locationArrowCanvas;
    private bool isTaskPaperRead = false;
    public TaskManager taskManagerScript;

    private void Start()
    {
        interactionInput.action.performed += Interact;
        dropInput.action.performed += Drop;
        useInput.action.performed += Use;
    }

    private void Use(InputAction.CallbackContext obj)
    {

    }

    private void Drop(InputAction.CallbackContext obj)
    {
        if (inHandItem != null)
        {
            inHandItem.transform.SetParent(null);
            inHandItem = null;
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (hit.collider.GetComponent<Cube>())
            {
                Debug.Log("It's cube!");
                // inHandItem = hit.collider.gameObject;
                // inHandItem.transform.position = Vector3.zero;
                // inHandItem.transform.rotation = Quaternion.identity;
                // inHandItem.transform.SetParent(pickUpParent.transform, false);
                // if (rb != null)
                // {
                //     rb.isKinematic = true;
                // }
                // return;

                inHandItem = hit.collider.gameObject;
                inHandItem.transform.SetParent(pickUpParent.transform, true);
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                return;
            }
        }
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
            // if (Input.GetKeyDown(KeyCode.R))
            // {
            //     PickUpObject(hit.collider.gameObject);
            // }
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
                    contactPaperLocationArrowScript.enabled = true;
                }
            }

            if (isTaskPaperRead)
            {
                if (hit.collider.GetComponent<ContactPaper>())
                {
                    Debug.Log("Hit contact paper");
                    hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                    pickUpUI.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        ReadObject(hit.collider.gameObject);
                    }

                    if (contactPaperUI.activeSelf)
                    {
                        pickUpUI.SetActive(false);
                        exitUI.SetActive(true);
                        contactDialogueBox.SetActive(true);
                    }

                    if (contactPaperUI.activeSelf && Input.GetKeyDown(KeyCode.X))
                    {
                        Debug.Log("Closing contact paper UI");
                        contactPaperUI.SetActive(false);
                        contactDialogueBox.SetActive(false);
                        exitUI.SetActive(false);
                        clicker.gameObject.SetActive(true);
                        // MouseLook.paperActive = false;
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

        if (obj.name == "A4_Lined_Paper_FBX (1)")
        {
            Debug.Log("Read object: " + obj.name);
            contactPaperUI.SetActive(true);
            contactPaperLocationArrowScript.enabled = false;
            // MouseLook.paperActive = true;
        }
    }
}

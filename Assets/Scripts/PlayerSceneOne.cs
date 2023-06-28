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
    public GameObject clicker;

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
    //private bool canPickUp = false;

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
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
            //canPickUp = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickUpObject(hit.collider.gameObject);
            }
        }
        if (inHandItem != null)
        {
            return;
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
            //canPickUp = false;
            if (taskPaperUI.activeSelf)
            {
                Debug.Log("Paper active, closing pick up UI");
                pickUpUI.SetActive(false);
                exitUI.SetActive(true);
            }

            if (contactPaperUI.activeSelf)
            {
                pickUpUI.SetActive(false);
                exitUI.SetActive(true);
                contactDialogueBox.SetActive(true);
            }
        }

        if (taskPaperUI.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Closing task paper UI");
            taskPaperUI.SetActive(false);
            exitUI.SetActive(false);
            clicker.SetActive(true);
            MouseLook.paperActive = false;
        }

        if (contactPaperUI.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Closing contact paper UI");
            contactPaperUI.SetActive(false);
            contactDialogueBox.SetActive(false);
            exitUI.SetActive(false);
            clicker.SetActive(true);
            MouseLook.paperActive = false;
        }
    }

    void PickUpObject(GameObject obj)
    {
        if (obj.name == "A4_Lined_Paper_FBX")
        {
            clicker.SetActive(false);
            taskPaperUI.SetActive(true);
            MouseLook.paperActive = true;
            Debug.Log("Picked up object: " + obj.name);
        }

        if (obj.name == "A4_Lined_Paper_FBX (1)")
        {
            clicker.SetActive(false);
            contactPaperUI.SetActive(true);
            MouseLook.paperActive = true;
            Debug.Log("Picked up object: " + obj.name);
        }
    }
}

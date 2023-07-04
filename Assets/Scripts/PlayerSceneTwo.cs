using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSceneTwo : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    [Min(1)]
    private float hitRange = 1;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    public GameObject pickUpUI;

    [SerializeField]
    private GameObject inHandItem;

    [SerializeField]
    private InputActionReference interactionInput, dropInput, useInput;

    [SerializeField]
    private Collider dropAreaCollider; // Collider representing the specific area for dropping the egg

    private RaycastHit hit;

    [SerializeField]
    private GameObject dropAreaAlert;

    [SerializeField]
    private GameObject dropUI;

    [SerializeField]
    private GameObject cataractUI;

    private bool alreadyInPan = false;

    // Start is called before the first frame update
    void Start()
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
        bool isInsideDropArea = IsInsideDropArea();
        if (!isInsideDropArea)
        {
            dropUI.SetActive(true);
            dropAreaAlert.SetActive(true); // Activate the alert UI element if not inside the drop area
        }
        if (inHandItem != null && isInsideDropArea)
        {
            dropUI.SetActive(false);
            dropAreaAlert.SetActive(false);
            inHandItem.transform.SetParent(null);
            inHandItem = null;
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
            }
            alreadyInPan = true;
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (hit.collider.GetComponent<Egg>())
            {
                Debug.Log("It's Egg!");
                dropUI.SetActive(true);
                inHandItem = hit.collider.gameObject;
                inHandItem.transform.SetParent(pickUpParent.transform, true);
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                cataractUI.SetActive(true);
                return;
            }
        }
    }

    // Check if the inHandItem is inside the drop area
    private bool IsInsideDropArea()
    {
        if (inHandItem != null && dropAreaCollider != null)
        {
            Collider itemCollider = inHandItem.GetComponent<Collider>();
            if (itemCollider != null)
            {
                bool isInside = itemCollider.bounds.Intersects(dropAreaCollider.bounds);
                return isInside;
            }
        }
        return false;
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
        if (alreadyInPan)
        {
            return;
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
        }
        // Handle pickup and drop logic   
    }
}

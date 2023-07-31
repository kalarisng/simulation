using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

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
    private GameObject machineDropAreaAlert;

    [SerializeField]
    private GameObject dropUI;

    [SerializeField]
    private GameObject cataractUI;
    private bool onionAlreadyInPan = false;
    private bool eggAlreadyInPan = false;
    public GameObject egg;
    public GameObject onion;
    public GameObject plateWithEgg;
    public GameObject eggPanel;
    public GameObject onionPanel;

    [SerializeField]
    private DropArrow dropArrowScript;
    [SerializeField]
    private Collider machineCollider;
    [SerializeField]
    private EggLocationArrow eggLocationArrowScript;
    [SerializeField]
    private OnionLocationArrow onionLocationArrowScript;
    public TextMeshProUGUI taskThree;
    [SerializeField]
    private BlanketLocationArrow blanketLocationArrowScript;
    [SerializeField]
    private GameObject kitchenDoorCollider;
    [SerializeField]
    private Crouch crouchScript;
    [SerializeField]
    private Rest restScript;
    private int blanketsDroppedCount = 0;
    [SerializeField]
    private GameObject boxTwo;

    // Start is called before the first frame update
    void Start()
    {
        interactionInput.action.performed += Interact;
        dropInput.action.performed += Drop;
        eggLocationArrowScript.enabled = true;
    }

    private void Drop(InputAction.CallbackContext obj)
    {
        if (inHandItem.name == "onion" || inHandItem.name == "egg (1)")
        {
            bool isInsideDropArea = IsInsideDropArea();
            if (inHandItem != null && !isInsideDropArea)
            {
                dropUI.SetActive(true);
                dropAreaAlert.SetActive(true); // Activate the alert UI element if not inside the drop area
            }
            if (inHandItem != null && isInsideDropArea)
            {
                dropUI.SetActive(false);
                dropAreaAlert.SetActive(false);

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }

                if (inHandItem.name == "onion")
                {
                    Debug.Log("onion in pan");
                    onionAlreadyInPan = true;
                    onionPanel.SetActive(false);
                    dropArrowScript.enabled = false;
                }
                else if (inHandItem.name == "egg (1)")
                {
                    Debug.Log("egg in pan");
                    eggAlreadyInPan = true;
                    eggPanel.SetActive(false);
                    onionPanel.SetActive(true);
                    dropArrowScript.enabled = false;
                    onionLocationArrowScript.enabled = true;
                }

                inHandItem.transform.SetParent(null);
                inHandItem = null;
            }
        }
        if (inHandItem.name == "FirstBlanket" || inHandItem.name == "SecondBlanket" || inHandItem.name == "ThirdBlanket")
        {
            bool isInsideMachine = IsInsideMachine();
            if (inHandItem != null && !isInsideMachine)
            {
                dropUI.SetActive(true);
                machineDropAreaAlert.SetActive(true); // Activate the alert UI element if not inside the drop area
            }
            if (inHandItem != null && isInsideMachine)
            {
                dropUI.SetActive(false);
                dropAreaAlert.SetActive(false);

                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }

                if (inHandItem.name == "FirstBlanket" || inHandItem.name == "SecondBlanket" || inHandItem.name == "ThirdBlanket")
                {
                    Debug.Log("first blanket in machine");
                    inHandItem.SetActive(false);
                    blanketsDroppedCount++;
                }
                inHandItem = null;
            }
        }
    }

    private void Interact(InputAction.CallbackContext obj)
    {
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (hit.collider.GetComponent<Egg>() && !eggAlreadyInPan)
            {
                Debug.Log("It's Egg!");
                eggLocationArrowScript.enabled = false;
                dropArrowScript.enabled = true;
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
            if (hit.collider.GetComponent<Onion>() && !onionAlreadyInPan)
            {
                onionLocationArrowScript.enabled = false;
                dropArrowScript.enabled = true;
                dropUI.SetActive(true);
                inHandItem = hit.collider.gameObject;
                inHandItem.transform.SetParent(pickUpParent.transform, true);
                if (rb != null)
                {
                    rb.isKinematic = true;
                }
                // cataractUI.SetActive(true);
                return;
            }
            if (hit.collider.GetComponent<Blanket>())
            {
                dropUI.SetActive(true);
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

    // Check if the inHandItem is inside the washing machine
    private bool IsInsideMachine()
    {
        if (inHandItem != null && machineCollider != null)
        {
            Collider itemCollider = inHandItem.GetComponent<Collider>();
            if (itemCollider != null)
            {
                bool isInside = itemCollider.bounds.Intersects(machineCollider.bounds);
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
        if (onionAlreadyInPan && eggAlreadyInPan)
        {
            Debug.Log("both egg and onion in pan");
            egg.SetActive(false);
            onion.SetActive(false);
            plateWithEgg.SetActive(true);
            taskThree.gameObject.SetActive(true);
            blanketLocationArrowScript.enabled = true;
            crouchScript.enabled = true;
            restScript.enabled = true;
        }
        if (blanketsDroppedCount == 3)
        {
            boxTwo.SetActive(true);
        }
        if (inHandItem != null)
        {
            Debug.Log("something in hand!");
            return;
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            if (hit.collider.GetComponent<Egg>() && !eggAlreadyInPan)
            {
                // activate kitchen door collision
                kitchenDoorCollider.SetActive(true);
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);
            }
            if (eggAlreadyInPan && hit.collider.GetComponent<Onion>())
            {
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);
            }
            if (eggAlreadyInPan && onionAlreadyInPan && hit.collider.GetComponent<Blanket>())
            {
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);
            }
        }
    }
}

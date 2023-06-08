using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    [Min(1)]
    private float hitRange = 1;

    private RaycastHit hit;
    private bool canPickUp = false;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
            canPickUp = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                // call method to pick up object
                PickUpObject(hit.collider.gameObject);
            }
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
            pickUpUI.SetActive(true);
            canPickUp = false;
        }
    }

    private void PickUpObject(GameObject obj)
    {
        // Action to take when object is picked up
        Debug.Log("Picked up object: " + obj.name);
    }
}

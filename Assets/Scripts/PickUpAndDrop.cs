using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
    public GameObject obj;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, objContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    // Start is called before the first frame update
    private void Start()
    {
        if (!equipped)
        {
            rb.isKinematic = false;
            coll.isTrigger = false;
        }

        if (equipped)
        {
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.F) && !slotFull)
        {
            PickUp();
        }

        //drop if equipped & Q is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //make object child of camera and move it to default position
        transform.SetParent(objContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //make rigidbody kinematic and box collider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //set parent to null
        transform.SetParent(null);

        //object carries momentum of player
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //add force
        rb.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        //make rigidbody not kinematic and box collider normal
        rb.isKinematic = false;
        coll.isTrigger = false;
    }
}

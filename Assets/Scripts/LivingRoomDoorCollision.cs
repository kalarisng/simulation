using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomDoorCollision : MonoBehaviour
{
    [SerializeField]
    private Canvas dementiaCanvas;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("player collided with living room door");
        if (other.CompareTag("Player"))
        {
            dementiaCanvas.gameObject.SetActive(true);
        }
    }
}

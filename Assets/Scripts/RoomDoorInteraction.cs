using UnityEngine;

public class RoomDoorInteraction : MonoBehaviour
{
    public GameObject canvas;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("player collided with room door");
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }
}

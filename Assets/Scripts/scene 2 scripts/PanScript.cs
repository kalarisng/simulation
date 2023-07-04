using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            Debug.Log("Egg dropped into the pan!");
        }
    }
}


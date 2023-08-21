using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskQuestionCollider : MonoBehaviour
{
    [SerializeField]
    private Canvas taskQuestionCanvas;
    [SerializeField]
    private Canvas clicker;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit task question collider");
            clicker.gameObject.SetActive(false);
            taskQuestionCanvas.gameObject.SetActive(true);
        }
    }
}

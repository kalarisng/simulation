using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskQuestionCollider : MonoBehaviour
{
    [SerializeField]
    private Canvas taskQuestionCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit task question collider");
            taskQuestionCanvas.gameObject.SetActive(true);
        }
    }
}

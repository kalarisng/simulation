using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPanObject : MonoBehaviour
{
    [SerializeField]
    private Transform panObjectTransform;

    [SerializeField]
    private float yOffset = 2f; // Adjust this value as needed

    // Update is called once per frame
    void Update()
    {
        if (panObjectTransform != null)
        {
            // Calculate the desired position above the pan object
            Vector3 targetPosition = panObjectTransform.position + Vector3.up * yOffset;
            transform.position = targetPosition;
        }
    }
}



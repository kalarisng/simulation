using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPaperLocationArrow : MonoBehaviour
{
    public RawImage image;
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        image.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        // Ensure the image is active when the script is enabled
        image.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        // Deactivate the image when the script is disabled
        image.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float minX = image.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = image.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minX;

        Vector2 pos = Camera.main.WorldToScreenPoint(target.position + offset);

        if (Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            // Target is behind player
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        image.transform.position = pos;
    }
}

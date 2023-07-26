using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebriefOneLocationArrow : MonoBehaviour
{
    public RawImage image;
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        if (image != null)
            image.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        if (image != null)
            image.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        if (image != null)
            image.gameObject.SetActive(false);
    }

    void Update()
    {
        if (image == null)
            return; // Exit the Update method if the image is null

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

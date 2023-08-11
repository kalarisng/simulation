using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController characterCollider;
    public Canvas healthBarCanvas;
    // Start is called before the first frame update
    public GameObject crouchInstructionPanel;
    void Start()
    {
        characterCollider = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            crouchInstructionPanel.SetActive(false);
            if (!healthBarCanvas.gameObject.activeSelf)
            {
                healthBarCanvas.gameObject.SetActive(true);
            }
            characterCollider.height = 1.0f;
        }
        else
        {
            characterCollider.height = 2.0f;
        }
    }
}

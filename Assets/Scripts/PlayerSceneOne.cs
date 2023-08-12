using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerSceneOne : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private GameObject pickUpUI;

    [SerializeField]
    private GameObject exitUI;

    [SerializeField]
    private GameObject taskPaperUI;

    [SerializeField]
    private Canvas phoneUI;

    [SerializeField]
    public Canvas clicker;

    [SerializeField]
    [Min(1)]
    private float hitRange = 1;

    [SerializeField]
    private Transform pickUpParent;

    [SerializeField]
    private GameObject inHandItem;

    private RaycastHit hit;
    [SerializeField]
    private TaskPaperLocationArrow taskPaperLocationArrowScript;
    [SerializeField]
    private PhoneLocationArrow phoneLocationArrowScript;
    [SerializeField]
    private DebriefOneLocationArrow debriefOneLocationArrowScript;
    private bool isTaskPaperRead = false;
    private bool isPhoneRead = false;
    public TextMeshProUGUI taskTwo;
    public TaskManager taskManagerScript;
    public GameObject boxOne;
    public GameObject triggerDoorOpen;
    public Canvas debriefOneCanvas;
    [SerializeField]
    private RawImage starOne;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.red);
        if (hit.collider != null)
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            hit.collider.GetComponent<Highlight>()?.ToggleHighlight(false);
            pickUpUI.SetActive(false);
        }
        if (inHandItem != null)
        {
            return;
        }
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, hitRange, pickableLayerMask))
        {
            if (hit.collider.GetComponent<TaskPaper>())
            {
                Debug.Log("Hit task paper");
                hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                pickUpUI.SetActive(true);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    clicker.gameObject.SetActive(false);
                    ReadObject(hit.collider.gameObject);
                }

                if (taskPaperUI.activeSelf)
                {
                    Debug.Log("Paper active, closing pick up UI");
                    pickUpUI.SetActive(false);
                    exitUI.SetActive(true);
                }

                if (taskPaperUI.activeSelf && Input.GetKeyDown(KeyCode.X))
                {
                    Debug.Log("Closing task paper UI");
                    taskManagerScript.StartFadeIn();
                    clicker.gameObject.SetActive(true);
                    taskPaperUI.SetActive(false);
                    exitUI.SetActive(false);
                    phoneLocationArrowScript.enabled = true;
                }
            }

            if (isTaskPaperRead)
            {
                if (hit.collider.GetComponent<Phone>())
                {
                    Debug.Log("Hit phone");
                    hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                    pickUpUI.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        clicker.gameObject.SetActive(false);
                        ReadObject(hit.collider.gameObject);
                    }

                    if (phoneUI.gameObject.activeSelf)
                    {
                        pickUpUI.SetActive(false);
                        exitUI.SetActive(true);
                    }

                    if (phoneUI.gameObject.activeSelf && Input.GetKeyDown(KeyCode.X))
                    {
                        Debug.Log("Closing contact paper UI");
                        phoneUI.gameObject.SetActive(false);
                        exitUI.SetActive(false);
                        clicker.gameObject.SetActive(true);
                        taskTwo.gameObject.SetActive(true);
                        boxOne.SetActive(true);
                        debriefOneLocationArrowScript.enabled = true;
                    }
                }
            }

            if (isPhoneRead)
            {
                if (hit.collider.GetComponent<Box>())
                {
                    Debug.Log("Hit box");
                    hit.collider.GetComponent<Highlight>()?.ToggleHighlight(true);

                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        debriefOneCanvas.gameObject.SetActive(true);
                    }
                    if (debriefOneCanvas.gameObject.activeSelf && Input.GetKeyDown(KeyCode.X))
                    {
                        Debug.Log("Closing debrief one");
                        debriefOneCanvas.gameObject.SetActive(false);
                        exitUI.SetActive(false);
                        StartCoroutine(FadeInRawImage(starOne));
                        triggerDoorOpen.SetActive(true);
                        debriefOneLocationArrowScript.enabled = false;
                    }
                }
            }
        }
    }

    void ReadObject(GameObject obj)
    {
        if (obj.name == "A4_Lined_Paper_FBX")
        {
            Debug.Log("Read object: " + obj.name);
            taskPaperUI.SetActive(true);
            taskPaperLocationArrowScript.enabled = false;
            isTaskPaperRead = true;
            // MouseLook.paperActive = true;
        }

        if (obj.name == "smartphone")
        {
            Debug.Log("Read object: " + obj.name);
            phoneUI.gameObject.SetActive(true);
            phoneLocationArrowScript.enabled = false;
            isPhoneRead = true;
            // MouseLook.paperActive = true;
        }
    }

    private System.Collections.IEnumerator FadeInRawImage(RawImage rawImage)
    {
        // Set the initial alpha value to 0
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 0f);

        // Enable the RawImage GameObject
        rawImage.gameObject.SetActive(true);

        // Gradually increase the alpha value over time
        float elapsedTime = 0f;
        while (elapsedTime < 1.0f)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / 1.0f);
            rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, alpha);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha value is set to 1 when the fade-in is complete
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, 1f);
    }
}

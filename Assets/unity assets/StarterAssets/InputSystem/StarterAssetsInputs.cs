using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;

        public Canvas introCanvas;
        public GameObject taskList;
        public Canvas phoneCanvas;
        public Canvas debriefOneCanvas;
        public Canvas debriefTwoCanvas;
        public HealthBar healthBar;
        public Canvas taskQuestionCanvas;
        public Canvas supermarketListCanvas;
        public Canvas dementiaCanvas;
        public Canvas telephoneCanvas;
        public Canvas debriefThreeCanvas;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        private bool CanProcessInputs => !IsAnyCanvasActive();

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            if (CanProcessInputs && healthBar.slider.value > 0)
            {
                MoveInput(value.Get<Vector2>());
            }
            else
            {
                MoveInput(Vector2.zero);
            }
        }

        public void OnLook(InputValue value)
        {
            if (CanProcessInputs && healthBar.slider.value > 0)
            {
                LookInput(value.Get<Vector2>());
            }
            else
            {
                LookInput(Vector2.zero);
            }
        }
#endif

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            float sensitivity = 4f;
            look = newLookDirection * sensitivity;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (CanProcessInputs)
            {
                // SetCursorState(cursorLocked);
            }
        }

        public void SetCursorState(bool newState)
        {
            if (CanProcessInputs)
            {
                Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
                Cursor.visible = !newState; // Hide the cursor when it's locked, show it when it's unlocked
            }
        }


        public void DeactivateCanvas()
        {
            introCanvas.gameObject.SetActive(false);
        }

        private bool IsAnyCanvasActive()
        {
            return introCanvas.gameObject.activeSelf ||
            taskList.activeSelf ||
            phoneCanvas.gameObject.activeSelf ||
            debriefOneCanvas.gameObject.activeSelf ||
            debriefTwoCanvas.gameObject.activeSelf ||
            taskQuestionCanvas.gameObject.activeSelf ||
            supermarketListCanvas.gameObject.activeSelf ||
            dementiaCanvas.gameObject.activeSelf ||
            telephoneCanvas.gameObject.activeSelf ||
            debriefThreeCanvas.gameObject.activeSelf;
        }

        public void LockCharacterMovement(bool locked)
        {
            // Get the character controller or other movement component reference
            CharacterController controller = GetComponent<CharacterController>();

            // Lock or unlock the character's movement based on the locked parameter
            if (controller != null)
            {
                controller.enabled = !locked;
            }
        }
    }
}

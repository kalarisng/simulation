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
        // public bool jump;
        // public bool sprint;

        public Canvas introCanvas;
        public Canvas debriefOneCanvas;
        public Canvas debriefTwoCanvas;
        public HealthBar healthBar;
        public Canvas supermarketListCanvas;
        public Canvas dementiaCanvas;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			if (!introCanvas.gameObject.activeSelf &&
             !debriefOneCanvas.gameObject.activeSelf &&
              !debriefTwoCanvas.gameObject.activeSelf &&
               !supermarketListCanvas.gameObject.activeSelf &&
                !dementiaCanvas.gameObject.activeSelf)
            {
                // Check the health bar value
                if (healthBar.slider.value > 0)
                {
                    MoveInput(value.Get<Vector2>());
                }
                else
                {
                    // Health bar is below zero, stop moving
                    MoveInput(Vector2.zero);
                }
            }
		}

		public void OnLook(InputValue value)
		{
			if (!introCanvas.gameObject.activeSelf &&
             !debriefOneCanvas.gameObject.activeSelf &&
              !debriefTwoCanvas.gameObject.activeSelf &&
               !supermarketListCanvas.gameObject.activeSelf &&
                !dementiaCanvas.gameObject.activeSelf)
            {
                // Check the health bar value
                if (healthBar.slider.value > 0)
                {
                    LookInput(value.Get<Vector2>());
                }
                else
                {
                    // Health bar is below zero, stop looking
                    LookInput(Vector2.zero);
                }
            }
		}

		// public void OnJump(InputValue value)
		// {
		// 	JumpInput(value.isPressed);
		// }

		// public void OnSprint(InputValue value)
		// {
		// 	SprintInput(value.isPressed);
		// }
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

        // public void JumpInput(bool newJumpState)
        // {
        //     jump = newJumpState;
        // }

        // public void SprintInput(bool newSprintState)
        // {
        //     sprint = newSprintState;
        // }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!introCanvas.gameObject.activeSelf &&
             !debriefOneCanvas.gameObject.activeSelf &&
              !debriefTwoCanvas.gameObject.activeSelf &&
               !supermarketListCanvas.gameObject.activeSelf &&
                !dementiaCanvas.gameObject.activeSelf)
            {
                SetCursorState(cursorLocked);
            }
        }

        public void SetCursorState(bool newState)
        {
            if (!introCanvas.gameObject.activeSelf &&
             !debriefOneCanvas.gameObject.activeSelf &&
              !debriefTwoCanvas.gameObject.activeSelf &&
               !supermarketListCanvas.gameObject.activeSelf &&
                !dementiaCanvas.gameObject.activeSelf)
            {
                Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
                // Lock or unlock the character's movement based on the cursor lock state
                // LockCharacterMovement(newState);
            }
        }

        public void DeactivateCanvas()
        {
            introCanvas.gameObject.SetActive(false);
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

            // Unlock the cursor if the character's movement is locked
            SetCursorState(!locked);
        }
    }
}
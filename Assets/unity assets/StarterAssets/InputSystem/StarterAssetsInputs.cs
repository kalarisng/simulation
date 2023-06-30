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

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
		public void OnMove(InputValue value)
		{
			if (!introCanvas.gameObject.activeSelf && !debriefOneCanvas.gameObject.activeSelf) {
				MoveInput(value.Get<Vector2>());
			}
		}

		public void OnLook(InputValue value)
		{
			if(!introCanvas.gameObject.activeSelf && !debriefOneCanvas.gameObject.activeSelf && cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
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
            if (!introCanvas.gameObject.activeSelf && !debriefOneCanvas.gameObject.activeSelf)
            {
                SetCursorState(cursorLocked);
            }
        }

        private void SetCursorState(bool newState)
        {
            if (!introCanvas.gameObject.activeSelf && !debriefOneCanvas.gameObject.activeSelf)
            {
                Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
                // Lock or unlock the character's movement based on the cursor lock state
                LockCharacterMovement(newState);
            }
        }

        public void DeactivateCanvas()
        {
            introCanvas.gameObject.SetActive(false);
        }

        private void LockCharacterMovement(bool locked)
        {
            // Get the character controller or other movement component reference
            CharacterController controller = GetComponent<CharacterController>();

            // Lock or unlock the character's movement based on the locked parameter
            if (controller != null)
            {
                controller.enabled = !locked;
            }
        }

        // public void SetInputEnabled(bool enabled)
        // {
        // 	if (!enabled)
        // 	{
        // 		move = Vector2.zero;
        // 		look = Vector2.zero;
        // 	}
        // }
    }

}
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputManager
{
    public class InputManager : MonoBehaviour
    {
        private InputController.PlayerInputActions playerInputActions;

        private void Start()
        {
            var c = new InputController();
            playerInputActions = c.PlayerInput;
            playerInputActions.Enable();
            playerInputActions.Movement.performed += MovementInput;
        }

        private void MovementInput(InputAction.CallbackContext obj)
        {
            var value = playerInputActions.Movement.ReadValue<Vector2>();
            Vector2Int moveValue = new Vector2Int((int)value.x, (int)value.y);
            MainController mainController = MainController.Instance;
            Debug.Log($"Move value: {moveValue.x},{moveValue.y}");
            
            if(!mainController.boardController.CanMovePlayer(moveValue))
                return;

            mainController.playerController.Move(moveValue);
            mainController.boardController.Move();
        }
    }
}

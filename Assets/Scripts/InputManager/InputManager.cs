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
            
            if(!mainController.boardController.CanMovePlayer(moveValue))
                return;
            
            mainController.boardController.Move(moveValue);
            mainController.playerController.Move(moveValue);
        }
    }
}

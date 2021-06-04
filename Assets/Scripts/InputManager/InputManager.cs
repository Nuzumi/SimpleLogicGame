using UnityEngine;
using UnityEngine.InputSystem;

namespace InputManager
{
    public class InputManager : MonoBehaviour
    {
        private InputController.PlayerInputActions playerInputActions;
        private bool canMove;

        private void Start()
        {
            var c = new InputController();
            canMove = true;
            playerInputActions = c.PlayerInput;
            playerInputActions.Enable();
            playerInputActions.Movement.performed += MovementInput;
        }

        private void MovementInput(InputAction.CallbackContext obj)
        {
            if(!canMove)
                return;
            
            var value = playerInputActions.Movement.ReadValue<Vector2>();
            Vector2Int moveValue = new Vector2Int((int)value.x, (int)value.y);
            MainController mainController = MainController.Instance;
            Debug.Log($"Move value: {moveValue.x},{moveValue.y}");
            
            if(!mainController.boardController.CanMovePlayer(moveValue))
                return;

            canMove = false;
            mainController.playerController.Move(moveValue, OnMove);
        }
        
        private void OnMove()
        {
            MainController.Instance.boardController.Move();
            canMove = true;
        }
    }
}

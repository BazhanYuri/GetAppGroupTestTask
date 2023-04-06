using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TestTask
{
    [System.Serializable]
    public class PlayerController
    {
        [SerializeField] private PlayerInput _playerInput;


        public event Action ShootButtonPressed;

        private VariableJoystick _moveJoystick;
        private VariableJoystick _lookJoystick;

        private InputActions _inputActions;



        public void SetJoysticks(VariableJoystick move, VariableJoystick look)
        {
            _moveJoystick = move;
            _lookJoystick = look;
        }
        public void Awake()
        {
            _inputActions = new InputActions();
            _inputActions.ActionMap.Enable();
            _inputActions.ActionMap.Shoot.performed += InvokeShootButton;
        }

        

        public Vector2 GetMoveVector()
        {
            Vector2 moveVector = _inputActions.ActionMap.Movement.ReadValue<Vector2>();
            if (moveVector == Vector2.zero)
            {
                moveVector = _moveJoystick.Direction;
            }

            return moveVector;
        }
        public Vector2 GetLookVector()
        {
            Vector2 lookVector = _lookJoystick.Direction;

            return lookVector;
        }
        private void InvokeShootButton(InputAction.CallbackContext obj)
        {
            ShootButtonPressed?.Invoke();
        }
    }
}


using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        
        private Vector2 _currentDirection = Vector2.zero;

        private void Update()
        {
            if (Keyboard.current.upArrowKey.isPressed)
            {
                _currentDirection = Vector2.up;
            }
            else if (Keyboard.current.downArrowKey.isPressed)
            {
                _currentDirection = Vector2.down;
            }
            else if (Keyboard.current.rightArrowKey.isPressed)
            {
                _currentDirection = Vector2.right;
            }
            else if (Keyboard.current.leftArrowKey.isPressed)
            {
                _currentDirection = Vector2.left;
            }
            else
            {
                _currentDirection = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(_currentDirection * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Vector2Int currentDirection = Vector2Int.zero;

        private void Update()
        {
            if (Keyboard.current.upArrowKey.isPressed)
            {
                currentDirection = Vector2Int.up;
            }
            else if (Keyboard.current.downArrowKey.isPressed)
            {
                currentDirection = Vector2Int.down;
            }
            else if (Keyboard.current.rightArrowKey.isPressed)
            {
                currentDirection = Vector2Int.right;
            }
            else if (Keyboard.current.leftArrowKey.isPressed)
            {
                currentDirection = Vector2Int.left;
            }
            else
            {
                currentDirection = Vector2Int.zero;
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(new Vector3Int(currentDirection.x, currentDirection.y, 0));
        }
    }
}

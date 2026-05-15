using Dialogue;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        
        private Vector2 _currentDirection = Vector2.zero;
        private Rigidbody2D _rigidbody;
        private DialogueManager _dialogueManager;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _dialogueManager = FindAnyObjectByType<DialogueManager>();
            GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
            }
        }

        private void Update()
        {
            if (_dialogueManager is not null && _dialogueManager.IsDialogueActive)
            {
                return;
            }
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
            _rigidbody.MovePosition(_rigidbody.position + _currentDirection * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}

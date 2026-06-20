using Core;
using Dialogue;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;
using World;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        
        private Vector2 _currentDirection = Vector2.zero;
        private Rigidbody2D _rigidbody;
        private DialogueManager _dialogueManager;
        private UIManager _uiManager;
        private Animator _animator;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _dialogueManager = FindAnyObjectByType<DialogueManager>();
            _uiManager = FindAnyObjectByType<UIManager>();
            _animator = GetComponent<Animator>();
            
            SpawnPoint[] spawnPoints = FindObjectsByType<SpawnPoint>();
            if (spawnPoints != null)
            {
                foreach (SpawnPoint sp in spawnPoints)
                {
                    if (sp.SpawnId == SceneLoader.TargetSpawnId)
                    {
                        transform.position = sp.transform.position;
                        break;
                    }
                }
            }
        }

        private void Update()
        {
            if (_dialogueManager is not null && _dialogueManager.IsDialogueActive
                || _uiManager is not null && _uiManager.IsInventoryOpen)
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
            _animator.SetFloat("MoveX", _currentDirection.x);
            _animator.SetFloat("MoveY", _currentDirection.y);
        }

        private void FixedUpdate()
        {
            if (_dialogueManager is not null && _dialogueManager.IsDialogueActive
                || _uiManager is not null && _uiManager.IsInventoryOpen)
            {
                return;
            }
            _rigidbody.MovePosition(_rigidbody.position + _currentDirection * (moveSpeed * Time.fixedDeltaTime));
        }
    }
}

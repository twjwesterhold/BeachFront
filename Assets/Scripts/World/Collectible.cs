using Inventory;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

namespace World
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private Item item;

        private InventoryManager _inventoryManager;
        private bool _playerIsNearby;
        private TextMeshPro _dialoguePrompt;

        private void Awake()
        {
            GetComponent<SpriteRenderer>().sprite = item.ItemSprite;
            _dialoguePrompt = GetComponentInChildren<TextMeshPro>();
            _dialoguePrompt.enabled = false;
            _inventoryManager = FindAnyObjectByType<InventoryManager>();
        }

        private void Update()
        {
            if (_playerIsNearby && Keyboard.current.eKey.wasPressedThisFrame)
            {
                _inventoryManager.AddItem(item);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNearby = true;
                _dialoguePrompt.enabled = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNearby = false;
                _dialoguePrompt.enabled = false;
            }
        }
    }
}

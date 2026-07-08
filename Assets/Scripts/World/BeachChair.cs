using System.Linq;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace World
{
    public class BeachChair : MonoBehaviour
    {
        private TextMeshPro _dialoguePrompt;
        private bool _playerIsNearby;
        private bool _hasPinaColada;
        private InventoryManager _inventoryManager;

        private void Awake()
        {
            _inventoryManager = FindAnyObjectByType<InventoryManager>();
            _dialoguePrompt = GetComponentInChildren<TextMeshPro>();
            _dialoguePrompt.enabled = false;
        }
        
        private void Update()
        {
            if (_playerIsNearby && Keyboard.current.eKey.wasPressedThisFrame && !_hasPinaColada)
            {
                // TODO: WinGame();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNearby = true;
                if (_inventoryManager.Items.Any(item => item.ItemName == "Pina Colada"))
                {
                    _hasPinaColada = true;
                    _dialoguePrompt.enabled = true;
                }
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

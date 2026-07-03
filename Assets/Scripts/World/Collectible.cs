using System.Collections.Generic;
using Inventory;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

namespace World
{
    public class Collectible : MonoBehaviour
    {
        [SerializeField] private Item item;
        [SerializeField] private Item playerSwap;

        private InventoryManager _inventoryManager;
        private bool _playerIsNearby;
        private TextMeshPro _dialoguePrompt;
        private static HashSet<string> _collectedIds = new HashSet<string>();

        private void Awake()
        {
            GetComponent<SpriteRenderer>().sprite = item.ItemSprite;
            _dialoguePrompt = GetComponentInChildren<TextMeshPro>();
            _dialoguePrompt.enabled = false;
            _inventoryManager = FindAnyObjectByType<InventoryManager>();
            if (_collectedIds.Contains(item.ItemName))
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (_playerIsNearby && Keyboard.current.eKey.wasPressedThisFrame)
            {
                if (playerSwap is not null && _inventoryManager.Items.Contains(playerSwap))
                {
                    _inventoryManager.RemoveItem(playerSwap);
                    _inventoryManager.AddItem(item);
                    Destroy(gameObject);
                    _collectedIds.Add(item.ItemName);
                } else if (playerSwap is null)
                {
                    _inventoryManager.AddItem(item);
                    Destroy(gameObject);
                    _collectedIds.Add(item.ItemName);
                }
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

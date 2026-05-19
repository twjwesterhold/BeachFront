using System;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private Transform itemList;
        [SerializeField] private ItemRow itemRowPrefab;
        
        private InventoryManager _inventoryManager;
        
        public bool IsInventoryOpen => inventoryPanel.activeSelf;

        private void Awake()
        {
            _inventoryManager = transform.parent.GetComponentInChildren<InventoryManager>();
            _inventoryManager.OnItemAdded += AddItemRow;
        }

        private void Update()
        {
            if (Keyboard.current.iKey.wasPressedThisFrame)
            {
                ToggleInventory();
            }
        }

        private void ToggleInventory()
        {
            bool opening = !inventoryPanel.activeSelf;
            inventoryPanel.SetActive(opening);
        }

        private void AddItemRow(Item item)
        {
            ItemRow row = Instantiate(itemRowPrefab, itemList);
            row.itemName.text = item.ItemName;
            row.itemIcon.sprite = item.ItemSprite;
        }
    }
}


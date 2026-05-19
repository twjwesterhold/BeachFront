using System;
using Inventory;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private Transform itemList;
        [SerializeField] private GameObject itemRowPrefab;
        
        private InventoryManager _inventoryManager;
        
        public bool IsInventoryOpen => inventoryPanel.activeSelf;

        private void Awake()
        {
            _inventoryManager = transform.parent.GetComponentInChildren<InventoryManager>();
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

            if (opening)
            {
                PopulateInventory();
            }
        }

        private void PopulateInventory()
        {
            foreach (Transform child in itemList)
            {
                Destroy(child.gameObject);
            }

            foreach (Item item in _inventoryManager.Items)
            {
                GameObject row = Instantiate(itemRowPrefab, itemList);
            }
        }
    }
}


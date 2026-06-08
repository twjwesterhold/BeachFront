using System;
using System.Collections.Generic;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryPanel;
        [SerializeField] private Transform itemList;
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private ItemRow itemRowPrefab;
        [SerializeField] private int poolSize = 16;

        private InventoryManager _inventoryManager;
        private List<ItemRow> _rowPool = new List<ItemRow>();

        public bool IsInventoryOpen => inventoryPanel.activeSelf;

        private void Awake()
        {
            _inventoryManager = transform.parent.GetComponentInChildren<InventoryManager>();
            _inventoryManager.OnMoneyChanged += UpdateMoney;
            UpdateMoney(0);

            for (int i = 0; i < poolSize; i++)
            {
                ItemRow row = Instantiate(itemRowPrefab, itemList);
                row.gameObject.SetActive(false);
                _rowPool.Add(row);
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void Update()
        {
            if (Keyboard.current.iKey.wasPressedThisFrame)
            {
                ToggleInventory(_inventoryManager.Items, null);
            }
        }
        
        public void ToggleInventory(List<Item> items, Action<Item> onSelect)
        {
            bool opening = !inventoryPanel.activeSelf;
            if (opening) PopulateInventory(items, onSelect);
            inventoryPanel.SetActive(opening);
        }

        private void UpdateMoney(int money)
        {
            moneyText.text = $"Money: ${money}";
        }

        private void PopulateInventory(List<Item> items, Action<Item> onSelect)
        {
            for (int i = 0; i < _rowPool.Count; i++)
            {
                if (i < items.Count)
                {
                    _rowPool[i].itemName.text = items[i].ItemName;
                    _rowPool[i].itemIcon.sprite = items[i].ItemSprite;
                    _rowPool[i].OnSelect = onSelect;
                    _rowPool[i].gameObject.SetActive(true);
                }
                else
                {
                    _rowPool[i].gameObject.SetActive(false);
                }
            }
        }
    }
}
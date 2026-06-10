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
        private int _selectedItemIndex;
        private bool _justOpened;
        private bool _justClosed;
        private int _itemCount;

        public bool IsInventoryOpen => inventoryPanel.activeSelf || _justOpened || _justClosed;

        private void Awake()
        {
            _inventoryManager = transform.parent.GetComponentInChildren<InventoryManager>();
            _inventoryManager.OnMoneyChanged += UpdateMoney;
            UpdateMoney(_inventoryManager.Money);

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
            _justClosed = false;
            if (IsInventoryOpen)
            {
                if (Keyboard.current.upArrowKey.wasPressedThisFrame)
                {
                    if (_selectedItemIndex <= 0) return;
                    _rowPool[_selectedItemIndex].caret.gameObject.SetActive(false);
                    _selectedItemIndex--;
                    _rowPool[_selectedItemIndex].caret.gameObject.SetActive(true);
                }
                if (Keyboard.current.downArrowKey.wasPressedThisFrame)
                {
                    if (_selectedItemIndex >= _itemCount - 1) return;
                    _rowPool[_selectedItemIndex].caret.gameObject.SetActive(false);
                    _selectedItemIndex++;
                    _rowPool[_selectedItemIndex].caret.gameObject.SetActive(true);
                }
                if (!_justOpened && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    if (_itemCount != 0)
                    {
                        _rowPool[_selectedItemIndex].OnSelect?.Invoke(_rowPool[_selectedItemIndex].item);
                    }
                    ToggleInventory();
                }
                else if (_justOpened)
                {
                    _justOpened = false;
                }
            }
            if (Keyboard.current.iKey.wasPressedThisFrame)
            {
                _rowPool[_selectedItemIndex].caret.gameObject.SetActive(false);
                ToggleInventory(_inventoryManager.Items, null);
            }
        }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void ToggleInventory(List<Item> items = null, Action<Item> onSelect = null)
        {
            bool opening = !inventoryPanel.activeSelf;
            if (opening)
            {
                PopulateInventory(items, onSelect);
                _justOpened = true;
            }
            else
            {
                _justClosed = true;
            }
            _selectedItemIndex = 0;
            inventoryPanel.SetActive(opening);
        }

        private void UpdateMoney(int money)
        {
            moneyText.text = $"Money: ${money}";
        }

        private void PopulateInventory(List<Item> items, Action<Item> onSelect)
        {
            _itemCount = items.Count;
            for (int i = 0; i < _rowPool.Count; i++)
            {
                if (i < items.Count)
                {
                    if (i == 0)
                    {
                        _rowPool[i].caret.gameObject.SetActive(true);
                    }
                    _rowPool[i].item = items[i];
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

        public void SetMoneyVisible(bool visible)
        {
            moneyText.gameObject.SetActive(visible);
        }
    }
}
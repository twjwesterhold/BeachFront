using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]private int money;
        [SerializeField]private List<Item> items;
        
        public event Action<Item> OnItemAdded;
        
        public int Money => money;
        public List<Item> Items => items;

        // ReSharper disable Unity.PerformanceAnalysis
        public void AddItem(Item item)
        {
            items.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void AddMoney(int inflow)
        {
            money += inflow;
        }

        public bool RemoveMoney(int outflow)
        {
            if (money >= outflow)
            {
                money -= outflow;
                return true;
            }
            return false;
        }
    }
}

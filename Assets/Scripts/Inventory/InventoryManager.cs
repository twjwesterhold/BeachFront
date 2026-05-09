using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]private int money;
        [SerializeField]private List<Item> items = new List<Item>();
        
        public int Money => money;
        public List<Item> Items => items;

        public void AddItem(Item item)
        {
            items.Add(item);
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

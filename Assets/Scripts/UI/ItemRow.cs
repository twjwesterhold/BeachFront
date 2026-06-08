using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Inventory;

namespace UI
{
    public class ItemRow : MonoBehaviour
    {
        public Item item;
        public TextMeshProUGUI itemName;
        public Image itemIcon;
        public TextMeshProUGUI caret;
        public Action<Item> OnSelect;
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Inventory;

namespace UI
{
    public class ItemRow : MonoBehaviour
    {
        public TextMeshProUGUI itemName;
        public Image itemIcon;
        public Action<Item> OnSelect;
    }
}

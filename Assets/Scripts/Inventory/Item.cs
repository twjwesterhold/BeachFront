using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]private string itemName;
        [SerializeField]private Sprite itemSprite;
        [SerializeField]private int itemPrice;
        
        public string ItemName => itemName;
        public Sprite ItemSprite => itemSprite;
        public int ItemPrice => itemPrice;
    }
}

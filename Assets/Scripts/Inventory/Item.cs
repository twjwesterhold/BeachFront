using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
    public class Item : ScriptableObject
    {
        [SerializeField]private string itemName;
        [SerializeField]private Sprite itemSprite;
        
        public string ItemName => itemName;
        public Sprite ItemSprite => itemSprite;
    }
}

using System.Linq;
using Dialogue;
using Inventory;
using UnityEngine;

namespace NPCs
{
    public class JoeController : MonoBehaviour
    {
        [SerializeField]private Item lure;
        [SerializeField]private Item worms;
        [SerializeField]private Item hat;
        [SerializeField]private Sprite postTradeSprite;
        
        private NPCController _npcController;
        private InventoryManager _inventoryManager;
        private static bool _tradeCompleted;
        private SpriteRenderer _spriteRenderer;
        
        private void Awake()
        {
            _inventoryManager = FindAnyObjectByType<InventoryManager>();
            _npcController = GetComponent<NPCController>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            if (_tradeCompleted)
            {
                _spriteRenderer.sprite = postTradeSprite;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (_tradeCompleted)
                {
                    _npcController.SetDialogueIndex(2);
                }
                else if (_inventoryManager.Items.Any(item => item.ItemName == "Lure") &&
                    _inventoryManager.Items.Any(item => item.ItemName == "Worms"))
                {
                    _npcController.SetDialogueIndex(1);
                }
                else
                {
                    _npcController.SetDialogueIndex(0);
                }
            }
        }

        public void CompleteTrade()
        {
            _inventoryManager.RemoveItem(lure);
            _inventoryManager.RemoveItem(worms);
            _inventoryManager.AddItem(hat);
            _tradeCompleted = true;
            _spriteRenderer.sprite = postTradeSprite;
        }
    }
}

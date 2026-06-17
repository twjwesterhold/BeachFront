using System.Collections.Generic;
using Inventory;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI npcNameText;
        [SerializeField]private TextMeshProUGUI npcTitleText;
        [SerializeField]private TextMeshProUGUI dialogueLineText;
        [SerializeField]private GameObject dialogueBox;
        [SerializeField]private GameObject optionsPanel;
        [SerializeField]private TextMeshProUGUI option1Text;
        [SerializeField]private TextMeshProUGUI option2Text;
        
        private DialogueData _currentDialogue;
        private int _currentLineIndex;
        private bool _justClosed;
        private int _selectedOptionIndex;
        private UIManager _uiManager;
        private List<Item> _npcInventory;
        private InventoryManager _inventoryManager;
        
        public bool IsDialogueActive => _currentDialogue is not null || _justClosed;

        private void Awake()
        {
            _uiManager = transform.parent.GetComponentInChildren<UIManager>();
            _inventoryManager = transform.parent.GetComponentInChildren<InventoryManager>();
        }

        private void Update()
        {
            _justClosed = false;
            if (!optionsPanel.activeSelf)
            {
                if (_currentDialogue is not null && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    AdvanceDialogue();
                }
                return;
            }

            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                SelectOption(_selectedOptionIndex);
            }
            if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            {
                _selectedOptionIndex = 0;
                UpdateOptionDisplay();
            }
            if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                _selectedOptionIndex = 1;
                UpdateOptionDisplay();
            }
        }

        public void StartDialogue(string npcName, string npcTitle, DialogueData dialogue, List<Item> npcInventory)
        {
            _currentLineIndex = 0;
            _currentDialogue = dialogue;
            _npcInventory = npcInventory;
            OpenDialogueBox(npcName, npcTitle);
            DisplayLine(_currentDialogue.Lines[_currentLineIndex]);
        }

        public void AdvanceDialogue()
        {
            if (_currentDialogue is null)
            {
                return;
            }
            _currentLineIndex++;
            if (_currentLineIndex >= _currentDialogue.Lines.Length)
            {
                if (_currentDialogue.Choice is not null)
                {
                    optionsPanel.SetActive(true);
                    UpdateOptionDisplay();
                }
                else
                {
                    CloseDialogueBox();
                }
            }
            else
            {
                DisplayLine(_currentDialogue.Lines[_currentLineIndex]);
            }
        }

        private void DisplayLine(string line)
        {
            dialogueLineText.text = line;
        }
        
        private void UpdateOptionDisplay()
        {
            option1Text.text = (_selectedOptionIndex == 0 ? "> " : "") + _currentDialogue.Choice.Option1;
            option2Text.text = (_selectedOptionIndex == 1 ? "> " : "") + _currentDialogue.Choice.Option2;
        }
        
        public void SelectOption(int optionIndex)
        {
            ChoiceData.ChoiceAction action = optionIndex == 0 
                ? _currentDialogue.Choice.Option1Action 
                : _currentDialogue.Choice.Option2Action;
        
            switch (action)
            {
                case ChoiceData.ChoiceAction.None: break;
                case ChoiceData.ChoiceAction.EndDialogue: break;
                case ChoiceData.ChoiceAction.OpenShop: 
                    _uiManager.ToggleInventory(_npcInventory, item => {
                        if (_inventoryManager.RemoveMoney(item.ItemPrice))
                        {
                            _inventoryManager.AddItem(item);
                            _npcInventory.Remove(item);
                        }
                    });
                    break;
                case ChoiceData.ChoiceAction.OpenSell:
                    _uiManager.ToggleInventory(_inventoryManager.Items, item => {
                        _inventoryManager.RemoveItem(item);
                        _inventoryManager.AddMoney(item.ItemPrice / 2);
                    });
                    break;
                case ChoiceData.ChoiceAction.BuyPinaColada:
                    if (_inventoryManager.RemoveMoney(_npcInventory[0].ItemPrice))
                    {
                        _inventoryManager.AddItem(_npcInventory[0]);
                    }
                    break;
                // other cases
            }
    
            CloseDialogueBox();
        }

        private void OpenDialogueBox(string npcName, string npcTitle)
        {
            dialogueBox.SetActive(true);
            npcNameText.text = npcName;
            npcTitleText.gameObject.SetActive(!string.IsNullOrEmpty(npcTitle));
            npcTitleText.text = npcTitle;
        }

        private void CloseDialogueBox()
        {
            _justClosed = true;
            dialogueBox.SetActive(false);
            _currentDialogue = null;
            _selectedOptionIndex = 0;
            optionsPanel.SetActive(false);
        }
    }
}

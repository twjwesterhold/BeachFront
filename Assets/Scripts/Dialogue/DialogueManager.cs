using TMPro;
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
        
        private DialogueData _currentDialogue;
        private int _currentLineIndex;
        private bool _justClosed;
        
        public bool IsDialogueActive => _currentDialogue is not null || _justClosed;

        private void Update()
        {
            _justClosed = false;
            if (_currentDialogue is not null && Keyboard.current.eKey.wasPressedThisFrame)
            {
                AdvanceDialogue();
            }
        }

        public void StartDialogue(string npcName, string npcTitle, DialogueData dialogue)
        {
            _currentLineIndex = 0;
            _currentDialogue = dialogue;
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
                CloseDialogueBox();
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
        }
    }
}

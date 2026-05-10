using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI npcNameText;
        [SerializeField]private TextMeshProUGUI npcTitleText;
        [SerializeField]private TextMeshProUGUI dialogueLineText;
        [SerializeField]private GameObject dialogueBox;
        
        private Dialogue _currentDialogue;
        private int _currentLineIndex;

        public void StartDialogue(Dialogue dialogue)
        {
            _currentLineIndex = 0;
            _currentDialogue = dialogue;
            OpenDialogueBox();
            DisplayLine(_currentDialogue.Lines[_currentLineIndex]);
        }

        public void AdvanceDialogue()
        {
            if (_currentDialogue == null)
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

        private void OpenDialogueBox()
        {
            npcNameText.text = _currentDialogue.NPCName;
            npcTitleText.text = _currentDialogue.NPCTitle;
            dialogueBox.SetActive(true);
        }

        private void CloseDialogueBox()
        {
            dialogueBox.SetActive(false);
        }
    }
}

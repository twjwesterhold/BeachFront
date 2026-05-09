using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI npcNameText;
        [SerializeField]private TextMeshProUGUI npcTitleText;
        [SerializeField]private TextMeshProUGUI dialogueLineText;
        
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
            
        }

        private void CloseDialogueBox()
        {
            
        }
    }
}

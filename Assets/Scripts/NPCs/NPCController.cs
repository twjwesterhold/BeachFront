using Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace NPCs
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField]private string npcName;
        [SerializeField] private string npcTitle;
        [SerializeField]private DialogueData[] dialogues;
        
        private bool _playerIsNearby;
        private DialogueManager _dialogueManager;
        private int _currentDialogueIndex;
        private TextMeshPro _dialoguePrompt;

        private void Awake()
        {
            _dialogueManager = FindAnyObjectByType<DialogueManager>();
            _dialoguePrompt = GetComponentInChildren<TextMeshPro>(true);
        }

        private void Update()
        {
            if (_playerIsNearby && Keyboard.current.eKey.wasPressedThisFrame && !_dialogueManager.IsDialogueActive)
            {
                _dialogueManager.StartDialogue(npcName, npcTitle, dialogues[_currentDialogueIndex]);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNearby = true;
                _dialoguePrompt.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNearby = false;
                _dialoguePrompt.gameObject.SetActive(false);
            }
        }
    }
}

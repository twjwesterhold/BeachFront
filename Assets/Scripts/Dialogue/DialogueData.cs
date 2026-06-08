using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField]private string[] lines;
        [SerializeField]private ChoiceData choice;
        
        public string[] Lines => lines;
        public ChoiceData Choice => choice;
    }
}

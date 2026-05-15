using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
    public class DialogueData : ScriptableObject
    {
        [SerializeField]private string[] lines;
        
        public string[] Lines => lines;
    }
}

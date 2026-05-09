using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "Dialogue", menuName = "Scriptable Objects/Dialogue")]
    public class Dialogue : ScriptableObject
    {
        [SerializeField]private string npcName;
        [SerializeField]private string npcTitle;
        [SerializeField]private string[] lines;
        
        public string NPCName => npcName;
        public string NPCTitle => npcTitle;
        public string[] Lines => lines;
    }
}

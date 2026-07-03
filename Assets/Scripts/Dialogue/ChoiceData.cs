using UnityEngine;

namespace Dialogue
{
    [CreateAssetMenu(fileName = "ChoiceData", menuName = "Scriptable Objects/ChoiceData")]
    
    public class ChoiceData : ScriptableObject
    {
        public enum ChoiceAction { None, OpenShop, OpenSell, EndDialogue, BuyPinaColada, CompleteJoeTrade }
        
        [SerializeField]private string option1;
        [SerializeField]private string option2;
        [SerializeField]private ChoiceAction option1Action;
        [SerializeField]private ChoiceAction option2Action;
        [SerializeField]private string option1Response;
        [SerializeField]private string option2Response;
        
        public string Option1 => option1;
        public string Option2 => option2;
        public ChoiceAction Option1Action => option1Action;
        public ChoiceAction Option2Action => option2Action;
        public string Option1Response => option1Response;
        public string Option2Response => option2Response;
    }
}

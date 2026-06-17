using UnityEngine;

namespace World
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private string spawnId;
        public string SpawnId => spawnId;
    }
}

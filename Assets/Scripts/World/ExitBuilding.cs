using Core;
using UnityEngine;

namespace World
{
    public class ExitBuilding : MonoBehaviour
    {
        [SerializeField]private string sceneName;
        
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = FindAnyObjectByType<SceneLoader>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            { 
                _sceneLoader.LoadScene(sceneName);
            }
        }
    }
}

using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace World
{
    public class EnterBuilding : MonoBehaviour
    {
        [SerializeField]private string sceneName;
        
        private bool _playerIsNearby;
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = FindAnyObjectByType<SceneLoader>();
        }

        private void Update()
        {
            if (_playerIsNearby && Keyboard.current.eKey.wasPressedThisFrame)
            {
                _sceneLoader.LoadScene(sceneName);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNearby = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _playerIsNearby = false;
            }
        }
    }
}

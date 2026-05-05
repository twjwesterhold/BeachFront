using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private SceneLoader _sceneLoader;
        
        private void Awake()
        {
            DontDestroyOnLoad(transform.root.gameObject);
            _sceneLoader = transform.parent.GetComponentInChildren<SceneLoader>();
        }

        private void Start()
        {
            _sceneLoader.LoadScene("MainMenu");
        }
    }
}

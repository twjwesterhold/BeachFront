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
#if UNITY_EDITOR
            string targetScene = UnityEditor.EditorPrefs.GetString("EditorBootstrapper.TargetScene", "");
            if (!string.IsNullOrEmpty(targetScene) && targetScene != "Boot")
            {
                UnityEditor.EditorPrefs.DeleteKey("EditorBootstrapper.TargetScene");
                _sceneLoader.LoadScene(targetScene);
                return;
            }
#endif
            _sceneLoader.LoadScene("MainMenu");
            _sceneLoader.LoadScene("MainMenu");
        }
    }
}

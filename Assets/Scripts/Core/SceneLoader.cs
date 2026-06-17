using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : MonoBehaviour
    {
        public static string TargetSpawnId;
        private UIManager _uiManager;
        
        private void Awake()
        {
            _uiManager = transform.parent.GetComponentInChildren<UIManager>();
        }

        public void LoadScene(string sceneName, string spawnId = "Default")
        {
            TargetSpawnId = spawnId;
            SceneManager.LoadScene(sceneName);
            if (sceneName == "Boot" || sceneName == "MainMenu")
            {
                _uiManager.SetMoneyVisible(false);
            }
            else
            {
                _uiManager.SetMoneyVisible(true);
            }
        }
    }
}

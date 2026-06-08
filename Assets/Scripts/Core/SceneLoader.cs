using System;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : MonoBehaviour
    {
        private UIManager _uiManager;
        
        private void Awake()
        {
            _uiManager = transform.parent.GetComponentInChildren<UIManager>();
        }

        public void LoadScene(string sceneName)
        {
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

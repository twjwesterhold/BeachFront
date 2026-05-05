using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

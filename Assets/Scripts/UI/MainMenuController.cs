using Core;
using UnityEngine;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        public void PlayGame()
        {
            FindAnyObjectByType<SceneLoader>().LoadScene("BeachTown");
        }
    }
}

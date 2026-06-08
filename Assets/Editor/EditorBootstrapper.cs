using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public static class EditorBootstrapper
{
    private const string PreviousSceneKey = "EditorBootstrapper.PreviousScene";
    private const string BootScene = "Boot";
    

    static EditorBootstrapper()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            if (SceneManager.GetActiveScene().name != BootScene)
            {
                EditorPrefs.SetString(PreviousSceneKey, SceneManager.GetActiveScene().path);
                EditorPrefs.SetString("EditorBootstrapper.TargetScene", SceneManager.GetActiveScene().name);
                EditorApplication.isPlaying = false;
                EditorSceneManager.OpenScene("Assets/Scenes/Boot.unity");
                EditorApplication.isPlaying = true;
            }
        }
        else if (state == PlayModeStateChange.EnteredEditMode)
        {
            string previousScene = EditorPrefs.GetString(PreviousSceneKey, "");
            if (!string.IsNullOrEmpty(previousScene))
            {
                EditorSceneManager.OpenScene(previousScene);
            }
        }
    }
}
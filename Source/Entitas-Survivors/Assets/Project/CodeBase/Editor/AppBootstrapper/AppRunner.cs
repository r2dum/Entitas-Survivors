using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor.AppBootstrapper
{
    [InitializeOnLoad]
    public static class AppRunner
    {
        private const string BootstrapScenePath = "Assets/Project/Scenes/BootstrapScene.unity";
        private const string MenuPath = "Tools/App/Running via Bootstrap";
        private const string LogPrefix = "<color=#4AF626>[AppRunner]</color>";

        private static bool IsEnabled
        {
            get => EditorPrefs.GetBool(MenuPath, true);
            set => EditorPrefs.SetBool(MenuPath, value);
        }

        static AppRunner() =>
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

        [MenuItem(MenuPath)]
        private static void ToggleBootstrapSceneEntry() =>
            IsEnabled = !IsEnabled;

        [MenuItem(MenuPath, true)]
        private static bool ValidateToggleBootstrapSceneEntry()
        {
            Menu.SetChecked(MenuPath, IsEnabled);
            return true;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange playModeState)
        {
            if (IsEnabled == false)
                return;

            switch (playModeState)
            {
                case PlayModeStateChange.ExitingEditMode:
                    TryRedirectToBootstrap();
                    break;
                case PlayModeStateChange.EnteredPlayMode:
                    if (EditorSceneManager.playModeStartScene != null)
                        Debug.Log($"{LogPrefix} Running via <b>{EditorSceneManager.playModeStartScene.name}</b>");
                    break;
                case PlayModeStateChange.EnteredEditMode:
                    EditorSceneManager.playModeStartScene = null;
                    break;
            }
        }

        private static void TryRedirectToBootstrap()
        {
            Scene activeScene = SceneManager.GetActiveScene();

            if (activeScene.path == BootstrapScenePath)
                return;

            SceneAsset bootstrapSceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(BootstrapScenePath);

            if (bootstrapSceneAsset != null)
            {
                EditorSceneManager.SaveOpenScenes();
                EditorSceneManager.playModeStartScene = bootstrapSceneAsset;
            }
            else
            {
                AbortPlayMode();
            }
        }

        private static void AbortPlayMode()
        {
            EditorApplication.ExitPlaymode();
            Debug.LogError($"{LogPrefix} BootstrapScene not found at: <b>{BootstrapScenePath}</b>. Redirection failed");
        }
    }
}
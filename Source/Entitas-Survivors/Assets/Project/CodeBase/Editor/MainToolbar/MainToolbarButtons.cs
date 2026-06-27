using UnityEditor;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBase.Editor.MainToolbar
{
    public class MainToolbarButtons
    {
        [MainToolbarElement("Project/Show Project Settings", defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement ProjectSettingsButton()
        {
            Texture2D icon = EditorGUIUtility.IconContent("SettingsIcon").image as Texture2D;
            MainToolbarContent content = new(icon);
            return new MainToolbarButton(content, () => { SettingsService.OpenProjectSettings(); });
        }

        [MainToolbarElement("Timescale/Reset", defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement ResetTimeScaleButton()
        {
            Texture2D icon = EditorGUIUtility.IconContent("Refresh").image as Texture2D;
            MainToolbarContent content = new(icon, "Reset");
            MainToolbarButton button = new(content, () =>
            {
                Time.timeScale = 1f;
                UnityEditor.Toolbars.MainToolbar.Refresh("Timescale/Slider");
            });

            MainToolbarElementStyler.StyleElement<EditorToolbarButton>("Timescale/Reset", element =>
            {
                element.style.paddingLeft = 0f;
                element.style.paddingRight = 0f;
                element.style.marginLeft = 0f;
                element.style.marginRight = 0f;
                element.style.minWidth = 20f;
                element.style.maxWidth = 20f;

                Image image = element.Q<Image>();
                if (image != null)
                {
                    image.style.width = 12f;
                    image.style.height = 12f;
                }
            });

            return button;
        }
    }
}
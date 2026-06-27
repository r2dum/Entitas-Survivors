using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.UIElements;

namespace CodeBase.Editor.MainToolbar
{
    public class MainToolbarTimescaleSlider
    {
        private const float MinTimeScale = 0f;
        private const float MaxTimeScale = 5f;

        [MainToolbarElement("Timescale/Slider", defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement TimeSlider()
        {
            MainToolbarContent content = new("Time Scale", "Time Scale");
            MainToolbarSlider slider = new(content, Time.timeScale, MinTimeScale, MaxTimeScale, OnSliderValueChanged)
            {
                populateContextMenu = menu =>
                {
                    menu.AppendAction("Reset", _ =>
                    {
                        Time.timeScale = 1f;
                        UnityEditor.Toolbars.MainToolbar.Refresh("Timescale/Slider");
                    });
                }
            };

            MainToolbarElementStyler.StyleElement<VisualElement>("Timescale/Slider",
                element => { element.style.paddingLeft = 10f; });

            return slider;
        }

        private static void OnSliderValueChanged(float newValue) =>
            Time.timeScale = newValue;
    }
}
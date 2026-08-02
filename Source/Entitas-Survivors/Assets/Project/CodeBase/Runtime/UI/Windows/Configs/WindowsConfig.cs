using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.UI.Windows.Configs
{
  [CreateAssetMenu(fileName = nameof(WindowsConfig), menuName = "Configs/Windows/" + nameof(WindowsConfig))]
  public class WindowsConfig : ScriptableObject
  {
    public List<WindowConfig> WindowConfigs;
  }
}
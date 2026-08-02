using System;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.UI.Windows.Configs
{
  [Serializable]
  public class WindowConfig
  {
    public WindowTypeId TypeId;
    public AssetReference Reference;
  }
}
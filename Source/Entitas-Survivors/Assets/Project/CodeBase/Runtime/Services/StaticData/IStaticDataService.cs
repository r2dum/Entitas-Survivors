using CodeBase.Runtime.Meta.Features.AfkGain.Configs;
using CodeBase.Runtime.UI.Windows;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace CodeBase.Runtime.Services.StaticData
{
  public interface IStaticDataService
  {
    UniTask LoadAllAsync();
    AssetReference GetWindowReference(WindowTypeId typeId);
    AfkGainConfig GetAfkGainConfig();
  }
}
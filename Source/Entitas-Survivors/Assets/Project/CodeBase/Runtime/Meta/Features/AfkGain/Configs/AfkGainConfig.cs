using UnityEngine;

namespace CodeBase.Runtime.Meta.Features.AfkGain.Configs
{
  [CreateAssetMenu(fileName = nameof(AfkGainConfig), menuName = "Configs/Meta/" + nameof(AfkGainConfig))]
  public class AfkGainConfig : ScriptableObject
  {
    public float GoldPerSecond = 1;
  }
}
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Configs
{
  [CreateAssetMenu(fileName = nameof(WavesConfig), menuName = "Configs/Enemy/" + nameof(WavesConfig))]
  public class WavesConfig : ScriptableObject
  {
    public List<WaveSetup> Waves;
  }
}
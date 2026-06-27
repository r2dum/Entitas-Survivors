using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Abilities.Configs
{
  [CreateAssetMenu(fileName = nameof(AbilityConfig), menuName = "Configs/Ability/" + nameof(AbilityConfig))]
  public class AbilityConfig : ScriptableObject
  {
    public AbilityId AbilityId;
    public List<AbilityLevel> Levels;
  }
}
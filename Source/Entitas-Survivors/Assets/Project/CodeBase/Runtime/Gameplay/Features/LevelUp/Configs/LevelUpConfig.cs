using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp.Configs
{
  [CreateAssetMenu(fileName = nameof(LevelUpConfig), menuName = "Configs/LevelUp/" + nameof(LevelUpConfig))]
  public class LevelUpConfig : ScriptableObject
  {
    public int MaxLevel;
    public List<float> ExperienceForLevel;
  }
}
using System;
using CodeBase.Runtime.Gameplay.Features.Abilities;

namespace CodeBase.Runtime.Gameplay.Features.Enemies.Configs
{
  [Serializable]
  public class EnemyAbilitySetup
  {
    public AbilityId AbilityId;
    public int Level = 1;
  }
}
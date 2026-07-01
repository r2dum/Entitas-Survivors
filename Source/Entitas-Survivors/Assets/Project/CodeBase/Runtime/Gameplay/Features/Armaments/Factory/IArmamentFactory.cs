using CodeBase.Runtime.Gameplay.Features.Abilities;
using UnityEngine;

namespace CodeBase.Runtime.Gameplay.Features.Armaments.Factory
{
  public interface IArmamentFactory
  {
    GameEntity CreateVegetableBolt(int level, Vector3 at);
    GameEntity CreateRadialEnergyOrb(int level, Vector3 at);
    GameEntity CreateOrbitingMushroom(int level, Vector3 at, float phase);
    GameEntity CreateBouncingRuneStone(int level, Vector3 at);
    GameEntity CreateScatteringFireBall(int level, Vector3 at);
    GameEntity CreateScatteringFireBallShard(int level, Vector3 at);
    GameEntity CreateEffectAura(AbilityId parentAbilityId, int producerId, int level);
    GameEntity CreateExplosion(int producerId, Vector3 at);
  }
}
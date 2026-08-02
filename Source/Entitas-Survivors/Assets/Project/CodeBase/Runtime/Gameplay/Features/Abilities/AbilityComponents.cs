using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace CodeBase.Runtime.Gameplay.Features.Abilities
{
  [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
  [Game] public class ParentAbility : IComponent { [EntityIndex] public AbilityId Value; }
  
  [Game] public class VegetableBoltAbility : IComponent { }
  [Game] public class OrbitingMushroomAbility : IComponent { }
  [Game] public class RadialEnergyOrbAbility : IComponent { }
  [Game] public class BouncingRuneStoneAbility : IComponent { }
  [Game] public class DragonFruitAbility : IComponent { }
  [Game] public class ScatteringFireBallAbility : IComponent { }
  
  [Game] public class GarlicAuraAbility : IComponent { }
  [Game] public class HealAuraAbility : IComponent { }
  [Game] public class SpeedUpAuraAbility : IComponent { }
  
  [Game] public class UpgradeRequest : IComponent { }
  [Game] public class RecreatedOnUpgrade : IComponent { }
}
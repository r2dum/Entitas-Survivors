using CodeBase.Runtime.Gameplay.Core.Visuals.Enchants;
using CodeBase.Runtime.Gameplay.Features.Enchants.Behaviours;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Enchants
{
  [Game] public class EnchantTypeIdComponent : IComponent { public EnchantTypeId Value; }
  [Game] public class EnchantVisualsComponent : IComponent { public IEnchantVisuals Value; }
  [Game] public class EnchantHolderComponent : IComponent { public EnchantHolder Value; }
  
  [Game] public class PoisonEnchant : IComponent { }
  [Game] public class ExplosiveEnchant : IComponent { }
  [Game] public class SheepHexEnchant : IComponent { }
}
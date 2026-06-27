using CodeBase.Runtime.Gameplay.Features.Enchants.Systems;
using CodeBase.Runtime.Infrastructure.Systems;

namespace CodeBase.Runtime.Gameplay.Features.Enchants
{
  public sealed class EnchantFeature : Feature
  {
    public EnchantFeature(ISystemFactory systemFactory)
    {
      Add(systemFactory.Create<PoisonEnchantSystem>());
      Add(systemFactory.Create<ExplosiveEnchantSystem>());

      Add(systemFactory.Create<ApplyPoisonEnchantVisualsSystem>());
    }
  }
}
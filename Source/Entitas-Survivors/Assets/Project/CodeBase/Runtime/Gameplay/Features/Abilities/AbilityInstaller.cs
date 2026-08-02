using CodeBase.Runtime.Gameplay.Features.Abilities.Factory;
using CodeBase.Runtime.Gameplay.Features.Abilities.Upgrade;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Abilities
{
  public class AbilityInstaller : Installer<AbilityInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IAbilityFactory>().To<AbilityFactory>().AsSingle();
      Container.Bind<IAbilityUpgradeService>().To<AbilityUpgradeService>().AsSingle();
    }
  }
}
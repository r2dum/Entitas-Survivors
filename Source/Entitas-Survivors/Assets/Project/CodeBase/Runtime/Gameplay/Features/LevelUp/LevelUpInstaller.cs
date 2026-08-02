using CodeBase.Runtime.Gameplay.Features.LevelUp.Services;
using CodeBase.Runtime.Gameplay.Features.LevelUp.Windows;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.LevelUp
{
  public class LevelUpInstaller : Installer<LevelUpInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<ILevelUpService>().To<LevelUpService>().AsSingle();
      Container.Bind<IAbilityUIFactory>().To<AbilityUIFactory>().AsSingle();
    }
  }
}
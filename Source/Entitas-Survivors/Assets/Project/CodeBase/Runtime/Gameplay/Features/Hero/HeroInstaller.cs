using CodeBase.Runtime.Gameplay.Features.Hero.Factory;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Hero
{
  public class HeroInstaller : Installer<HeroInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IHeroFactory>().To<HeroFactory>().AsSingle();
  }
}
using CodeBase.Runtime.Gameplay.Features.Armaments.Factory;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Armaments
{
  public class ArmamentInstaller : Installer<ArmamentInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IArmamentFactory>().To<ArmamentFactory>().AsSingle();
  }
}
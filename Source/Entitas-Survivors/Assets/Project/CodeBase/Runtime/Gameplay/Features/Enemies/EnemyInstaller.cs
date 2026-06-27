using CodeBase.Runtime.Gameplay.Features.Enemies.Factory;
using Zenject;

namespace CodeBase.Runtime.Gameplay.Features.Enemies
{
  public class EnemyInstaller : Installer<EnemyInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
  }
}
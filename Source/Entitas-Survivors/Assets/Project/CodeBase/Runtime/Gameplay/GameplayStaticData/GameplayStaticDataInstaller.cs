using Zenject;

namespace CodeBase.Runtime.Gameplay.GameplayStaticData
{
  public class GameplayStaticDataInstaller : Installer<GameplayStaticDataInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<IGameplayStaticDataService>().To<GameplayStaticDataService>().AsSingle();
  }
}
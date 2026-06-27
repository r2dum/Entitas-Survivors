using Zenject;

namespace CodeBase.Runtime.Gameplay.Levels
{
  public class LevelInstaller : Installer<LevelInstaller>
  {
    public override void InstallBindings() =>
      Container.Bind<ILevelDataProvider>().To<LevelDataProvider>().AsSingle();
  }
}
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Installers
{
  public class ContextsInstaller : Installer<ContextsInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<Contexts>().FromInstance(Contexts.sharedInstance).AsSingle();
      Container.Bind<GameContext>().FromInstance(Contexts.sharedInstance.game).AsSingle();
    }
  }
}
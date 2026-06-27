using Zenject;

namespace CodeBase.Runtime.Infrastructure.StateMachine
{
  public class StateFactoryInstaller : Installer<StateFactoryInstaller>
  {
    public override void InstallBindings() =>
      Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
  }
}
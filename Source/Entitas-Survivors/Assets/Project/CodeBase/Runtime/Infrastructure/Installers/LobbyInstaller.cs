using CodeBase.Runtime.Infrastructure.GameFlowStateMachine.LobbyStates.Registrar;
using CodeBase.Runtime.Infrastructure.StateMachine;
using CodeBase.Runtime.Infrastructure.Systems;
using CodeBase.Runtime.UI.Windows;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.Installers
{
  public class LobbyInstaller : MonoInstaller
  {
    public override void InstallBindings()
    {
      WindowsInstaller.Install(Container);
      SystemFactoryInstaller.Install(Container);
      StateFactoryInstaller.Install(Container);
      LobbyStatesRegistrarInstaller.Install(Container);
    }
  }
}
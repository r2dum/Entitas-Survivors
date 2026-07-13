using Zenject;

namespace CodeBase.Runtime.Gameplay.Core.Visuals.Appearance
{
  public class AppearanceVisualsInstaller : Installer<AppearanceVisualsInstaller>
  {
    public override void InstallBindings() =>
      Container.BindInterfacesAndSelfTo<AppearanceSkinFactory>().AsSingle();
  }
}
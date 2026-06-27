using CodeBase.Runtime.Infrastructure.EntityView.Factory;
using Zenject;

namespace CodeBase.Runtime.Infrastructure.EntityView
{
  public class EntityViewInstaller : Installer<EntityViewInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IEntityViewFactory>().To<EntityViewFactory>().AsSingle();
    }
  }
}
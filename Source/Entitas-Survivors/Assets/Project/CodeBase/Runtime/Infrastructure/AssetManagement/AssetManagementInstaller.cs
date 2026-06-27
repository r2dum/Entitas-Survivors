using Zenject;

namespace CodeBase.Runtime.Infrastructure.AssetManagement
{
  public class AssetManagementInstaller : Installer<AssetManagementInstaller>
  {
    public override void InstallBindings()
    {
      Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
      Container.Bind<IEntityViewAssetLoader>().To<EntityViewAssetLoader>().AsSingle();
    }
  }
}
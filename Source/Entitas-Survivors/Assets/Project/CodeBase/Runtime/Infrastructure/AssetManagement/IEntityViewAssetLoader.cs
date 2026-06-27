namespace CodeBase.Runtime.Infrastructure.AssetManagement
{
  public interface IEntityViewAssetLoader
  {
    void Load(GameEntity entity, string address);
  }
}
using Entitas;

namespace CodeBase.Runtime.Meta.Features.Simulation.Systems
{
  public class AfkGoldGainSystem : IExecuteSystem
  {
    private readonly IGroup<MetaEntity> _ticks;
    private readonly IGroup<MetaEntity> _storages;

    public AfkGoldGainSystem(MetaContext metaContext)
    {
      _ticks = metaContext.GetGroup(MetaMatcher.Tick);

      _storages = metaContext.GetGroup(MetaMatcher
        .AllOf(
          MetaMatcher.Storage,
          MetaMatcher.Gold,
          MetaMatcher.GoldPerSecond));
    }

    public void Execute()
    {
      foreach (MetaEntity tick in _ticks)
      foreach (MetaEntity storage in _storages)
        storage.ReplaceGold(storage.Gold + tick.Tick * storage.GoldPerSecond);
    }
  }
}
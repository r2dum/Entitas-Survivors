using CodeBase.Runtime.Services.StaticData;
using Entitas;

namespace CodeBase.Runtime.Meta.Features.Simulation.Systems
{
  public class CalculateGoldGainSystem : IExecuteSystem
  {
    private readonly IStaticDataService _staticDataService;

    private readonly IGroup<MetaEntity> _boosters;
    private readonly IGroup<MetaEntity> _storages;

    public CalculateGoldGainSystem(MetaContext metaContext, IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;

      _boosters = metaContext.GetGroup(MetaMatcher.GoldGainBoost);

      _storages = metaContext.GetGroup(MetaMatcher
        .AllOf(
          MetaMatcher.Storage,
          MetaMatcher.GoldPerSecond));
    }

    public void Execute()
    {
      foreach (MetaEntity storage in _storages)
      {
        float gainBonus = 1;

        foreach (MetaEntity booster in _boosters)
          gainBonus += booster.GoldGainBoost;

        storage.ReplaceGoldPerSecond(_staticDataService.GetAfkGainConfig().GoldPerSecond * gainBonus);
      }
    }
  }
}
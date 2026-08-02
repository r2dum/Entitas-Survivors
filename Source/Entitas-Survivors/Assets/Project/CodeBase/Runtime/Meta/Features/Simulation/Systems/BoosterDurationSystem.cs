using Entitas;

namespace CodeBase.Runtime.Meta.Features.Simulation.Systems
{
  public class BoosterDurationSystem : IExecuteSystem
  {
    private readonly IGroup<MetaEntity> _boosters;
    private readonly IGroup<MetaEntity> _tick;

    public BoosterDurationSystem(MetaContext metaContext)
    {
      _tick = metaContext.GetGroup(MetaMatcher.Tick);

      _boosters = metaContext.GetGroup(MetaMatcher
        .AllOf(
          MetaMatcher.GoldGainBoost,
          MetaMatcher.Duration));
    }

    public void Execute()
    {
      foreach (MetaEntity tick in _tick)
      foreach (MetaEntity booster in _boosters)
      {
        booster.ReplaceDuration(booster.Duration - tick.Tick);

        if (booster.Duration <= 0)
          booster.isDestructed = true;
      }
    }
  }
}
using System.Collections.Generic;
using CodeBase.Runtime.Gameplay.Features.Effects;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Statuses.Systems.StatusVisuals
{
  public class UnapplyAppearanceSkinSystem : ReactiveSystem<GameEntity>
  {
    public UnapplyAppearanceSkinSystem(GameContext gameContext) : base(gameContext)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher
        .AllOf(
          GameMatcher.Status,
          GameMatcher.Unapplied)
        .Added());

    protected override bool Filter(GameEntity entity) =>
      entity.isStatus && entity.hasTargetId && entity.hasAppearanceSkin;

    protected override void Execute(List<GameEntity> statuses)
    {
      foreach (GameEntity status in statuses)
      {
        GameEntity target = status.Target();
        if (target is { hasAppearanceVisuals: true, isDead: false })
        {
          target.AppearanceVisuals.ClearSkin();
          target.UpdateStatusVisuals(target.AppearanceVisuals.CurrentSkin);
        }
      }
    }
  }
}
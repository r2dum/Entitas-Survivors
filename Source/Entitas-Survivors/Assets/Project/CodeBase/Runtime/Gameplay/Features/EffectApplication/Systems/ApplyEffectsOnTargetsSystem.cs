using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Effects.Factory;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.EffectApplication.Systems
{
  public class ApplyEffectsOnTargetsSystem : IExecuteSystem
  {
    private readonly IEffectFactory _effectFactory;
    private readonly IGroup<GameEntity> _entities;

    public ApplyEffectsOnTargetsSystem(GameContext gameContext, IEffectFactory effectFactory)
    {
      _effectFactory = effectFactory;
      _entities = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetBuffer,
          GameMatcher.EffectSetups));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      foreach (int targetId in entity.TargetBuffer)
      foreach (EffectSetup setup in entity.EffectSetups)
        _effectFactory.CreateEffect(setup, ProducerId(entity), targetId);
    }

    private static int ProducerId(GameEntity entity) =>
      entity.hasProducerId ? entity.ProducerId : entity.Id;
  }
}
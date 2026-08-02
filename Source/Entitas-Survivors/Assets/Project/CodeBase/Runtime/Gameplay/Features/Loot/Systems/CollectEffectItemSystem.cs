using CodeBase.Runtime.Gameplay.Features.Effects;
using CodeBase.Runtime.Gameplay.Features.Effects.Factory;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Systems
{
  public class CollectEffectItemSystem : IExecuteSystem
  {
    private readonly IEffectFactory _effectFactory;

    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _collected;

    public CollectEffectItemSystem(GameContext gameContext, IEffectFactory effectFactory)
    {
      _effectFactory = effectFactory;

      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Hero,
          GameMatcher.WorldPosition));

      _collected = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collected,
          GameMatcher.EffectSetups));
    }

    public void Execute()
    {
      foreach (GameEntity collected in _collected)
      foreach (GameEntity hero in _heroes)
      foreach (EffectSetup effectSetup in collected.EffectSetups)
        _effectFactory.CreateEffect(effectSetup, hero.Id, hero.Id);
    }
  }
}
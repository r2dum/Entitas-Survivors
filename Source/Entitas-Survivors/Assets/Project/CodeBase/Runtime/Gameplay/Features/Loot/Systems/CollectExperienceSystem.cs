using CodeBase.Runtime.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace CodeBase.Runtime.Gameplay.Features.Loot.Systems
{
  public class CollectExperienceSystem : IExecuteSystem
  {
    private readonly ILevelUpService _levelUpService;

    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _collected;

    public CollectExperienceSystem(GameContext gameContext, ILevelUpService levelUpService)
    {
      _levelUpService = levelUpService;
      _heroes = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));

      _collected = gameContext.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collected,
          GameMatcher.Experience));
    }

    public void Execute()
    {
      foreach (GameEntity collected in _collected)
      foreach (GameEntity hero in _heroes)
      {
        _levelUpService.AddExperience(collected.Experience);
        hero.ReplaceExperience(_levelUpService.CurrentExperience);
      }
    }
  }
}